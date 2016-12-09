using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TryLinq
{
    public class DelimitedDataReader : IDisposable
    {
        private FileStream _stream;
        private TextReader _reader;

        private string _path;
        private bool _hasHeaders;
        private int _leadingLinesToSkip;
        private int _trailingLinesToSkip;
        private char _delimiter;
        private bool _initialized = false;

        private List<string> _currentRecord;
        private Queue<List<string>> _recordQueue = new Queue<List<string>>();
        private Dictionary<string, int> _headerMap;
        private int _lineNumber = 0;
        private List<char> _fieldBuffer = new List<char>();
        private List<char> _lineBuffer = new List<char>();

        public string this[string header]
        {
            get
            {
                if (!_hasHeaders || _headerMap == null)
                {
                    throw new Exception("Cannot reference data by header, the data source does not contain headers.");
                }
                InsureRecord();
                return _currentRecord[_headerMap[header]];
            }
        }

        public string this[int index]
        {
            get
            {
                InsureRecord();
                return _currentRecord[index];
            }
        }

        public DelimitedDataReader(string path, bool hasHeaders, int leadingLinesToSkip, int trailingLinesToSkip, char delimiter)
        {
            _path = path;
            _hasHeaders = hasHeaders;
            _leadingLinesToSkip = leadingLinesToSkip;
            _trailingLinesToSkip = trailingLinesToSkip;
            _delimiter = delimiter;
        }

        public bool Read()
        {
            if (!_initialized)
            {
                _initialized = true;
                Init();
            }

            if (QueueRecord())
            {
                _currentRecord = _recordQueue.Dequeue();
                return true;
            }
            _currentRecord = null;
            return false;
        }

        private void InsureRecord()
        {
            if (_currentRecord == null)
            {
                throw new ApplicationException("Can't access a field. There is no current record. Did you call Read()?");
            }
        }

        private void Init()
        {
            if (!File.Exists(_path))
            {
                throw new IOException(string.Format("File: {0} does not exist.", _path));
            }
            _stream = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.Read);
            _reader = new StreamReader(_stream);

            while (_leadingLinesToSkip-- > 0 && QueueRecord())
            {
                _lineNumber++;
            }
            _recordQueue.Clear();

            if (_hasHeaders && QueueRecord())
            {
                int i = 0;
                _headerMap = _recordQueue.Dequeue().ToDictionary(item => item, item => i++);
                _lineNumber++;
            }

            while (_trailingLinesToSkip-- > 0 && QueueRecord()) { }
        }

        private enum Phase
        {
            BeginField,
            Reading,
            ReadingQuoted,
            Escaped,
            EndField,
            EOL
        }

        private bool QueueRecord()
        {
            if (_reader.Peek() < 0)
            {
                return false;
            }

            List<string> record = new List<string>();
            Phase phase = Phase.BeginField;
            int next = -1;
            char c;
            _lineBuffer.Clear();

            while (phase != Phase.EOL && (next = _reader.Read()) > -1)
            {
                c = (char)next;
                _lineBuffer.Add(c);
                switch (phase)
                {
                    case Phase.BeginField:
                        if (c == _delimiter)
                        {
                            record.Add(string.Empty);

                        }
                        else if (c == '"')
                        {
                            phase = Phase.ReadingQuoted;
                            //ignore leading whitespace
                        }
                        else if (!char.IsWhiteSpace(c))
                        {
                            _fieldBuffer.Add(c);
                            phase = Phase.Reading;
                        }
                        else if (IsNewLine(c))
                        {
                            phase = Phase.EOL;
                        }
                        break;
                    case Phase.Reading:
                        if (c == _delimiter)
                        {
                            record.Add(new string(_fieldBuffer.ToArray(), 0, _fieldBuffer.Count));
                            _fieldBuffer.Clear();
                            phase = Phase.BeginField;
                        }
                        else if (IsNewLine(c))
                        {
                            phase = Phase.EOL;
                        }
                        else
                        {
                            _fieldBuffer.Add(c);
                        }
                        break;
                    case Phase.ReadingQuoted:
                        if (c == '"')
                        {
                            phase = Phase.Escaped;
                        }
                        else
                        {
                            _fieldBuffer.Add(c);
                        }
                        break;
                    case Phase.Escaped:
                        if (c == _delimiter)
                        {
                            record.Add(new string(_fieldBuffer.ToArray(), 0, _fieldBuffer.Count));
                            _fieldBuffer.Clear();
                            phase = Phase.BeginField;
                        }
                        else if (c == '"')
                        {
                            _fieldBuffer.Add(c);
                            phase = Phase.ReadingQuoted;
                        }
                        else if (IsNewLine(c))
                        {
                            phase = Phase.EOL;
                            //allow trailing whitespace, end field
                        }
                        else if (char.IsWhiteSpace(c))
                        {
                            phase = Phase.EndField;
                            //don't allow text after a closing quote
                        }
                        else
                        {
                            RaiseParseException();
                        }
                        break;
                    case Phase.EndField:
                        if (c == _delimiter)
                        {
                            record.Add(new string(_fieldBuffer.ToArray(), 0, _fieldBuffer.Count));
                            _fieldBuffer.Clear();
                            phase = Phase.BeginField;
                        }
                        else if (IsNewLine(c))
                        {
                            phase = Phase.EOL;
                        }
                        else if (!char.IsWhiteSpace(c))
                        {
                            RaiseParseException();
                        }
                        break;
                    default:
                        break;
                }
            }

            record.Add(new string(_fieldBuffer.ToArray(), 0, _fieldBuffer.Count));
            _fieldBuffer.Clear();

            _recordQueue.Enqueue(record);
            _lineNumber++;
            return true;
        }

        private bool IsNewLine(char current)
        {
            if (current == '\n')
            {
                return true;
            }
            else if (current == '\r')
            {
                if ((char)_reader.Peek() == '\n')
                {
                    _reader.Read();
                }
                return true;
            }
            return false;
        }

        private void RaiseParseException()
        {
            throw new FormatException(
                string.Format("Could not parse delimited data. Line number {0}: \"{1}\" is improperly quoted.",
                    _lineNumber,
                    string.Concat(new string(_lineBuffer.ToArray(), 0, _lineBuffer.Count), _reader.ReadLine())
                    )
                );
        }

        #region IDisposable Members

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (_reader != null)
                {
                    _reader.Close();
                    _reader = null;
                }
                if (_stream != null)
                {
                    _stream.Close();
                    _stream = null;
                }
            }
        }

        #endregion

    }
}

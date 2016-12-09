using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Program
    {
        const string FilePath = @"C:\src\softwareGuild\repos\mpls-dotnet-september-2016-materials\words.txt";

        public List<Word> GetAllWords()
        {
            throw new NotImplementedException();
        }
        static void Main(string[] args)
        {
            List<Word> words = new List<Word>();
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    Word newWord = new Word();
                    newWord.Words = lines;
                    words.Add(newWord);
                }
            }
            List<Word> sortedWords = new List<Word>();
            foreach (var word in words)
            {
                char[] char1 = word.Words.ToLower().ToCharArray();
                Array.Sort(char1);
                string newWord = new string(char1);
                Word newNewWord = new Word();
                newNewWord.Words = newWord;
                sortedWords.Add(newNewWord);
            }

        }

        public List<Word> SortWords(List<Word> words)
        {
            throw new NotImplementedException();
        }
        public bool AnagramCheck(string one, string two)
        {
            if (one.Length != two.Length)
            {
                return false;
            }
            foreach (var letters in two)
            {
                int c = one.IndexOf(letters);
                if (c >= 0)
                {
                    one = one.Remove(c, 1);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}

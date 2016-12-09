using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
            return "<" + tag + ">" + content + "</" + tag + ">";
        }

        public string InsertWord(string container, string word)
        {
            return container.Insert(2, word);
        }

        public string MultipleEndings(string str)
        {
            string name = str.Substring(str.Length -2);
            return name + name + name;
        }

        public string FirstHalf(string str)
        {
            return str.Remove(str.Length / 2);
        }

        public string TrimOne(string str)
        {
            string stringMinusEnd = str.Remove(str.Length - 1);
            string trimmed = stringMinusEnd.Substring(1);
            return trimmed;
        }

        public string LongInMiddle(string a, string b)
        {
            if (b.Length >= 1)
            {
                return a + b + a;
            }
            else
            {
                return b + a + b;
            }
        }

        public string RotateLeft2(string str)
        {
            if (str.Length <= 2)
            {
                return str;
            }
            string end = str.Substring(2); 
            string start = str.Remove(2);
            return end + start;
        }

        public string RotateRight2(string str)
        {
            if (str.Length <= 2)
            {
                return str;
            }
            string end = str.Substring(str.Length-2);
            string start = str.Remove(2);
            return end + start;
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                return str.Substring(0, 1);
            }
            else
            {
                return str.Substring(str.Length - 1);
            }
        }

        public string MiddleTwo(string str)
        {
            int middle = str.Length / 2;
            return str.Substring(middle -1, 2);

        }

        public bool EndsWithLy(string str)
        {
            if (str.EndsWith("ly"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public string FrontAndBack(string str, int n)
        {
            front 
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            throw new NotImplementedException();
        }

        public bool HasBad(string str)
        {
            throw new NotImplementedException();
        }

        public string AtFirst(string str)
        {
            throw new NotImplementedException();
        }

        public string LastChars(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string ConCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string SwapLast(string str)
        {
            throw new NotImplementedException();
        }

        public bool FrontAgain(string str)
        {
            throw new NotImplementedException();
        }

        public string MinCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string TweakFront(string str)
        {
            throw new NotImplementedException();
        }

        public string StripX(string str)
        {
            throw new NotImplementedException();
        }
    }
}

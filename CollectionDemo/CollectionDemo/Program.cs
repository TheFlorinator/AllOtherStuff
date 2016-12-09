using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "Hello World!";
            int myInteger = 42;
            char myCharacter = 'z';

            ArrayList arrayList = new ArrayList();
            arrayList.Add(myString);
            arrayList.Add(myInteger);
            arrayList.Add(myCharacter);

            List<string> myStrings = new List<string>();
            myStrings.Add("hello guild!");
            myStrings.Add("Hello world!");

            Hashtable hastable = new Hashtable();
            hastable.Add(0, myString);
            hastable.Add(1, myInteger);
            hastable.Add(2, myCharacter);

            Queue<string> myQueBiz = new Queue<string>();
            Stack<string> justThatRegularBiz = new Stack<string>();

            Queue queue = new Queue();
            queue.Add


            //Queue queue = new Queue();
            //Stack stack = new Stack();

        }
    }
}

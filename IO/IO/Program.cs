using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IO
{
    class Program
    {
        const string HOME_PATH = @"C:\Users\cmarch";
        const string ALICE_PATH = "alice-in-wonderland.txt";

        static void Main(string[] args)
        {
            //using (FileStream stream = File.Create("data"))
            //using (BinaryWriter writer = new BinaryWriter(stream))
            //{
            //    writer.Write(Math.PI);
            //    writer.Write(int.MaxValue);
            //    writer.Write(string.Empty);
            //    writer.Write(DateTime.Now.Ticks);
            //}

            using (FileStream stream = File.Open("data", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                double pie = reader.ReadDouble();
                int max = reader.ReadInt32();
            }




            Console.ReadLine();
        }
    }
}

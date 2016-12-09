using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWIthEFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogContext())
            {

                var blog = context.Blogs.First();
                blog.Url = "http://super.singlet.com";

                context.SaveChanges();

            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}

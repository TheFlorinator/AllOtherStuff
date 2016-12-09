using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MplsMoviesEntities())
            {
                var gladiator = context.Movies.FirstOrDefault(i => i.Title.Equals("Gladiator"));
                
                
            }
        }
    }
}

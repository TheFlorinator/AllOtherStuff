using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new ProductRepository();
            var singlet = repo.ById(78);
            singlet.ProductName = "Singlet";


            repo.Save(singlet);

            Console.ReadKey();
        }

      
    }
}

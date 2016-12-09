using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace PlayingWithDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"];

            using (SqlConnection conn = new SqlConnection(connectionString.ConnectionString))
            {
                var parms = new DynamicParameters();
                parms.Add("ProductName", "Gross Singlet");
                parms.Add("ProductId", DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute(
                    "[ProductsInsert]",
                    parms,
                    commandType: CommandType.StoredProcedure);

                var productId = parms.Get<int>("ProductId");

            }

            Console.ReadKey();
        }
    }
}

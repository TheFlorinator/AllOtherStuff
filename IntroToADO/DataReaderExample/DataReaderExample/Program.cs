using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DataReaderExample
{
    class Program
    {
        static void Main()
        {
            DisplayEmployeeList();
            Console.ReadLine();
        }

        private static void DisplayEmployeeList()
        {
            string connectionString;
            connectionString = ConfigurationManager
                                    .ConnectionStrings["Northwind"]
                                    .ConnectionString;

            // create connection with connection string
            // using to automatically close it
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // Create a command
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT * FROM Employees";
                    cmd.Connection = cn;

                    cn.Open(); // must have open connection to query

                    // call ExecuteReader to have the command create a 
                    // data reader, this executes the SQL Statement
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        //Read() returns false when there is no more data
                        while (dr.Read())
                        {
                            Console.WriteLine("{0} {1}, {2}",
                                dr["EmployeeID"].ToString(),
                                dr["LastName"].ToString(),
                                dr["FirstName"].ToString());                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter to continue...");
                Console.ReadLine();
            }

        }
    }
}

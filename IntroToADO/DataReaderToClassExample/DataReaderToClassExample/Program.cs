using Northwind.DataLayer.Models;
using Northwind.DataLayer.Repositories;
using System;

namespace DataReaderToClassExample
{
    class Program
    {
        static void Main()
        {
            //ShowAllEmployees();
            //LoadSingleEmployee();
            LoadSingleEmployeeStoredProcedure();
            Console.ReadLine();
        }

        private static void ShowAllEmployees()
        {
            EmployeeRepository repo = new EmployeeRepository();

            Console.WriteLine("All Employees");
            Console.WriteLine("-------------");
            foreach (Employee e in repo.GetAll())
            {
                Console.WriteLine("{0:D2} {1,-17} {2} {3:d}", e.EmployeeId, e.LastName + ", " + e.FirstName, e.Title, e.BirthDate);
                if (e.ReportsTo.HasValue)
                    Console.WriteLine("\tReports to: {0}", e.ManagerName);
                Console.WriteLine();
            }
        }

        private static void LoadSingleEmployee()
        {
            EmployeeRepository repo = new EmployeeRepository();
            Employee e = repo.GetById(5);

            Console.WriteLine("{0:D2} {1,-17} {2} {3:d}", e.EmployeeId, e.LastName + ", " + e.FirstName, e.Title, e.BirthDate);
            if (e.ReportsTo.HasValue)
                Console.WriteLine("\tReports to: {0}", e.ManagerName);
            Console.WriteLine();
        }

        private static void LoadSingleEmployeeStoredProcedure()
        {
            EmployeeRepository repo = new EmployeeRepository();
            Employee e = repo.GetByIdStoredProcedure(5);

            Console.WriteLine("{0:D2} {1,-17} {2} {3:d}", e.EmployeeId, e.LastName + ", " + e.FirstName, e.Title, e.BirthDate);
            if (e.ReportsTo.HasValue)
                Console.WriteLine("\tReports to: {0}", e.ManagerName);
            Console.WriteLine();           
        }
    }
}

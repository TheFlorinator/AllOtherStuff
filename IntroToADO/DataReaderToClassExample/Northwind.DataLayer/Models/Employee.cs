using System;

namespace Northwind.DataLayer.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? ReportsTo { get; set; }
        public string ManagerName { get; set; }
    }
}

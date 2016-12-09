using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDofThings.Models
{
    public class Borrower
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Review { get; set; }
    }
}

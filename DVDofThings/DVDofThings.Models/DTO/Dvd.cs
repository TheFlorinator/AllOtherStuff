using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDofThings.Models
{
    public class Dvd
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Year { get; set; }
        public int RunTime { get; set; }
        public MPAARatings MPAARating { get; set; }
        public int NumberRating { get; set; }
        public string Genre { get; set; }
        public List<Borrower> Borrowers { get; set; }
        public List<Actor> Actors { get; set; }
    }
}

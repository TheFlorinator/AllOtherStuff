using DVDofThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDofThings.Data
{
    public class DVDRepo : IRepository
    {
        private static List<Dvd> _Dvds;

        static DVDRepo()
        {
            _Dvds = new List<Dvd>();
            var dvdOne = new Dvd
            {
                Name = "Man on Fire",
                Id = 1,
                Year = 2002,
                RunTime = 137,
                MPAARating = MPAARatings.R,
                Actors = new List<Actor>()
                    {
                       new Actor() { Name = "Denzel Washington", Id = 1 },
                       new Actor() { Name = "Vin Diesel", Id = 2 }
                    },
                Borrowers = new List<Borrower>()
                {
                    new Borrower() {Name = "Jason Florin", Id = 1, RentDate = null, ReturnDate= null, Review = "Best movie that has ever been made" }
                },
                Genre = "Action",
                NumberRating = 8,
            };
            _Dvds.Add(dvdOne);

            var dvdTwo = new Dvd
            {
                Name = "Gladiator",
                Id = 2,
                Year = 2002,
                RunTime = 137,
                MPAARating = MPAARatings.R,
                Actors = new List<Actor>()
                    {
                       new Actor() { Name = "Russel Crowe", Id = 3 },
                       new Actor() { Name = "Walking the Phonenix", Id = 4 }
                    },
                Borrowers = new List<Borrower>()
                {
                    new Borrower() {Name = "Tom Florin", Id = 2, RentDate = null, ReturnDate= null, Review = "Amazing movie, it literally changed my life" }
                },
                Genre = "Action",
                NumberRating = 8,
            };
            _Dvds.Add(dvdTwo);

            var dvdThree = new Dvd
            {
                Name = "10 Things I Hate About You",
                Id = 3,
                Year = 2002,
                RunTime = 137,
                MPAARating = MPAARatings.R,
                Actors = new List<Actor>()
                    {
                       new Actor() { Name = "Heeth Ledger", Id = 1 },
                       new Actor() { Name = "That Other Girl", Id = 2 }
                    },
                Borrowers = new List<Borrower>()
                {
                    new Borrower() {Name = "Hannah Florin", Id = 3, RentDate = null, ReturnDate= null, Review = "This movie makes me cry every time" }
                },
                Genre = "Romance",
                NumberRating = 8,
            };
            _Dvds.Add(dvdThree);

            var dvdFour = new Dvd
            {
                Name = "Hot Rod", 
                Id = 4,
                Year = 2002,
                RunTime = 137,
                MPAARating = MPAARatings.R,
                Actors = new List<Actor>()
                    {
                       new Actor() { Name = "Andy Samburg", Id = 5 },
                       new Actor() { Name = "That Other Guy", Id = 6 }
                    },
                Borrowers = new List<Borrower>()
                {
                    new Borrower() {Name = "Heidi VanBockle", Id = 4, RentDate = null, ReturnDate= null, Review = "Best movie that has ever been made" }
                },
                Genre = "Comedy",
                NumberRating = 8,
            };
            _Dvds.Add(dvdFour);
        }

        public void AddBorrower(Borrower newBorrower)
        {
            throw new NotImplementedException();
        }

        public void AddMovie(Dvd newDvd)
        {
            _Dvds.Add(newDvd);
        }

        public bool DeleteBorrower(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMovie(int id)
        {
            if (_Dvds.Any(d => d.Id == id))
            {
                _Dvds.RemoveAll(d => d.Id == id);
                return true;
            }
            return false;
        }

        public List<Borrower> GetAllBorrower()
        {
            List<Borrower> borrowers = new List<Borrower>();
            foreach (var dvd in _Dvds)
            {
                foreach (var borrower in dvd.Borrowers)
                {
                    borrowers.Add(borrower);
                }
            }
            return borrowers;
        }

        public List<Dvd> GetAllDvds()
        {
            List<Dvd> Dvds = new List<Dvd>();
            foreach (var dvd in _Dvds)
            {
                Dvds.Add(dvd);
            }
            return Dvds;
        }
    }
}

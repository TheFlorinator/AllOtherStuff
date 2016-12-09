using DVDofThings.Logic;
using DVDofThings.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDofThings.Tests
{
    [TestFixture]
    public class InMemory
    {
        [Test]
        public void CanGetAllDvds()
        {
            DvdCzar czar = new DvdCzar();
            var dvds = czar.GetTheMovies();
            Assert.AreEqual(4, dvds.TheDrop.Count());
        }

        [Test]
        public void CanGetAllBorrowers()
        {
            DvdCzar czar = new DvdCzar();
            var dvds = czar.GetAllBorrowers();
            Assert.AreEqual(4, dvds.TheDrop.Count());
            Assert.IsTrue(dvds.TheDrop.Where(n => n.Name == "Jason Florin").Count() == 1);
        }

        [TestCase("An Awesome Movie", "A genre", 5, true)]
        [TestCase("", "A genre", 5, false)]
        [TestCase("An Awesome Movie", "A genre", 5, true)]
        [TestCase("An Awesome Movie",  "", 5, false)]
        [TestCase("An Awesome Movie", "A genre", 11, false)]
        public void CanAddAMovie(string name, string genre, int rating, bool expectedResults)
        {
            DvdCzar czar = new DvdCzar();
            var dvd = new Dvd();
            dvd.Name = name;
            dvd.Genre = genre;
            dvd.NumberRating = rating;
            var response = czar.AddAMovie(dvd);
            Assert.AreEqual(expectedResults, response.Success);

        }

        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(-2, false)]
        [TestCase(15, false)]
        public void CanDeleteMovie(int id, bool expectedResult)
        {
            DvdCzar czar = new DvdCzar();
            var response = czar.DeleteDvd(id);
            Assert.AreEqual(response.Success, expectedResult);
        }
    }
}

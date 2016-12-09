using DVDofThings.Logic;
using DVDofThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DVDofThings.UI.Controllers
{
    public class HomeController : ApiController
    {
        public List<Dvd> GetDvds()
        {
            DvdCzar czar = new DvdCzar();
            return czar.GetTheMovies().TheDrop;
        }

        public List<Borrower> GetBorrowers()
        {
            DvdCzar czar = new DvdCzar();
            return czar.GetAllBorrowers().TheDrop;
        }
    }
}

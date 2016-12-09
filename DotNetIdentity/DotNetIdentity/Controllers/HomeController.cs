using DotNetIdentity.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetIdentity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult ShowUserInfo()
        {
            var dataStore = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = dataStore.FindByNameAsync(User.Identity.Name).Result;
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminOnly()
        {
            return View();
        }
    }
}
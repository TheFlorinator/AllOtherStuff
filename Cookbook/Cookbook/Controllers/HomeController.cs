using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookbook.Models;
using Cookbook.Helpers;

namespace Cookbook.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new GenericModel
            {
                Now = DateTime.Now,
                IsValid = true,
                Name = "Corn",
                Number = 314
            };
            return View(model);
        }

        public ActionResult RequestDetails(string first, string second, string third)
        {
            ViewBag.Controller = 123;
            ViewBag.Fiest = first;
            ViewBag.Second = second;
            ViewBag.Third = third;
            return View();
        }


        [HttpGet]
        public ActionResult Wrestler()
        {
            var model = new Wrestler
            {
                Id = 1,
                Name = "John Cena",
                WeightClass = WeightClass.Heavy,
                MuscleDensity = 1.0m,
                Tattoos = new List<Tattoo> {
                    new Tattoo
                    {
                        Location = "Face/Neck",
                        Color = "Black",
                        Size = 3,
                        Toughness = 10,
                        IsVisible = true
                    },
                    new Tattoo
                    {
                        Location = "Lowerback",
                        Color = "Grey",
                        Size = 1,
                        Toughness = -1,
                        IsVisible = false
                    }
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Wrestler(Wrestler model)
        {           
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Tattoo()
        {
            return View(new Tattoo { Location = "Face" });
        }

        [HttpPost]
        public ActionResult Tattoo(Tattoo model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Bootstrap()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser()
        {
            return Content("done");
        }
    }
}
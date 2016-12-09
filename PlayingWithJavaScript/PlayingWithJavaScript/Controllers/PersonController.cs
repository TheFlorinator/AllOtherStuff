using Data;
using PlayingWithJavaScript.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPerson = PlayingWithJavaScript.Models.Person;

namespace PlayingWithJavaScript.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var model = new MPerson();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(MPerson model)
        {
            return View(model);
        }

        public ActionResult AddValidate()
        {
            var model = new MPerson();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddValidate(MPerson model)
        {           
            return View(model);
        }        
      
        [HttpPost]
        public ActionResult AllPeople()
        {
            PersonDataStore store = new PersonDataStore();
            return Json(store.All());
        }
    }
}
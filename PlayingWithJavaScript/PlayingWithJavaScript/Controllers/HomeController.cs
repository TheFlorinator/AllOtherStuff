using PlayingWithJavaScript.Models;
using System.Web.Mvc;

namespace PlayingWithJavaScript.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {           
            return View();
        }

        public ActionResult People()
        {
            return View();
        }

        public ActionResult OnePerson()
        {
            return View();
        }

        public ActionResult Add()
        { 
            return View();
        }
        
    }
}
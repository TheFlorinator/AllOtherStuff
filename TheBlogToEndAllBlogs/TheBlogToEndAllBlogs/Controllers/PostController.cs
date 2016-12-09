using TheBlogToEndAllBlogs.Logic;
using TheBlogToEndAllBlogs.Models;
using TheBlogToEndAllBlogs.ViewModels;
using TheBlogToEndAllBlogs;
using TheBlogToEndAllBlogs.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geocoding;

namespace TheBlogToEndAllBlogs.Controllers
{
    public class PostController : Controller
    {
        Rules rules = new Rules();

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult WritePost()
        {
            PostVM vm = new PostVM();
            vm.HashTags = rules.GetAllTags();
            return View(vm);  
        }

        [HttpPost]
        public ActionResult WritePost(Post p)
        {
            rules.AddPost(p);
            return RedirectToAction("Post");
        }


        [HttpGet]
        public ActionResult Post()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Publish()
        {
            PostVM vm = new PostVM();
            vm.HashTags = rules.GetAllTags();
            return View(vm);
          
        }
 
        [HttpGet]
        public ActionResult Review(int postId)
        {
            return View();
        }
    }
}
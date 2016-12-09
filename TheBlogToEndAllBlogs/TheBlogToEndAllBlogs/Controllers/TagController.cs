using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheBlogToEndAllBlogs.Logic;
using TheBlogToEndAllBlogs.Models;
using TheBlogToEndAllBlogs.ViewModels;


namespace TheBlogToEndAllBlogs.Controllers
{
    public class TagController : ApiController
    {
        private Rules _rules;

        public TagController()
        {
            _rules = new Rules();
        }

        [HttpPost]
        public Tag Save(Tag tag)
        {
            return _rules.SaveTag(tag).Post;
        }
    }
}

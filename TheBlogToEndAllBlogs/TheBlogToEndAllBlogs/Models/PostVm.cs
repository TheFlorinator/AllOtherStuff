using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheBlogToEndAllBlogs.Models
{
    public class PostVm
    {
        public Post Post { get; set; }
        public List<Post> Posts { get; set; }
        
    }

   
}
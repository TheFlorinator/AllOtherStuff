using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBlogToEndAllBlogs.Models;

namespace TheBlogToEndAllBlogs.ViewModels
{
    public class PostVM
    {
        public List<Tag> HashTags { get; set; }
        
        public Post Post { get; set; } 

        public Post SelectedPost { get; set; }

        public Post AddPost { get; set; }

        public List<Post>UnPublishedPosts { get; set; }

        public Post Publish { get; set; }

        public Post Review { get; set; }
    }
}
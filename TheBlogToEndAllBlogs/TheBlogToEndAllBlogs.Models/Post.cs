using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;

namespace TheBlogToEndAllBlogs.Models
{
    public class Post
    {
        public string Title { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Image { get; set; }
        public Address Address { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public List<Tag> HashTags { get; set; }
        public bool Published { get; set; }
        public int PostId { get; set; }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlogToEndAllBlogs.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string StreetTwo { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public int ZipCode { get; set; }

    }
}

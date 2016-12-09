using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public class GenericModel
    {
        public DateTime Now { get; set; }
        public bool IsValid { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
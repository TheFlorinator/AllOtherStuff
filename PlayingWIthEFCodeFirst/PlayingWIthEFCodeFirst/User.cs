using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PlayingWIthEFCodeFirst
{
    public class User
    {
        [Key]        
        public string UserName { get; set; }

        public string DisplayName { get; set; }
    }
}

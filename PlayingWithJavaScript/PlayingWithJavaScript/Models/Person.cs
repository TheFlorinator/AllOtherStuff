using Data;
using System.ComponentModel.DataAnnotations;

namespace PlayingWithJavaScript.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [RegularExpression(@"^[\w\.]+@[\w\.]+\.\w+$", ErrorMessage = "Please enter a valid email address.")]
        public string EmailAddress { get; set; }
      
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public string Buzzwords { get; set; }       

    }
}
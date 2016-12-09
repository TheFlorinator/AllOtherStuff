using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Cookbook.Helpers;

namespace Cookbook.Models
{
    [WeightClassMustMakeSense(ErrorMessage = "The weight class and muscle density must make sense.")]
    public class Wrestler
    {
        public int Id { get; set; }

        [Display(Name = "Wrestler")]
        [Required(ErrorMessage = "We only recognize John Cena!")]
        public string Name { get; set; }

        [Display(Name = "Weight Class")]
        public WeightClass WeightClass { get; set; }

        [Display(Name = "Muscle Density")]
        [Range(0.001, 1.0, ErrorMessage = "Muscle Density must be greater than 0 and less than or equal to 1.")]
        public decimal MuscleDensity { get; set; }

        public DateTime Birthday { get; set; }

        public List<Tattoo> Tattoos { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public class Tattoo : IValidatableObject
    {
        public string Location { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public int Toughness { get; set; }
        public bool IsVisible { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (string.IsNullOrWhiteSpace(Location))
            {
                result.Add(new ValidationResult("Location is required", new string[] { "Location" }));
            }
            if (Size <= 0)
            {
                result.Add(new ValidationResult("Size must be greater than zero.", new string[] { "Size" }));
            }
            if (!IsVisible && Location == "Face")
            {
                result.Add(new ValidationResult("Face tattoos are always visible (and kinda cool).", 
                    new string[] { "Location", "IsVisible" }));
            }
            return result;
        }

        public IEnumerable<ValidationResult> ValidateToo(ValidationContext validationContext)
        {           
            if (string.IsNullOrWhiteSpace(Location))
            {
                yield return new ValidationResult("Location is required", new string[] { "Location" });
            }
            if (Size <= 0)
            {
                yield return new ValidationResult("Size must be greater than zero.", new string[] { "Size" });
            }
            if (!IsVisible && Location == "Face")
            {
                yield return new ValidationResult("Face tattoos are always visible (and kinda cool).",
                    new string[] { });
            }           
        }
    }
}
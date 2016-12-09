using Cookbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookbook.Helpers
{
    public class WeightClassMustMakeSenseAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Wrestler model = value as Wrestler;
            if (model != null)
            {
                return !(model.WeightClass == WeightClass.Heavy && model.MuscleDensity < 0.5m);
            }
            return false;
        }
    }
}
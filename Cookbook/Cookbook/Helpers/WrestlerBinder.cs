using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookbook.Models;

namespace Cookbook.Helpers
{
    public class WrestlerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = new Wrestler();
            result.Name = controllerContext.RequestContext.HttpContext.Request.Form["Name"];
            int day = int.Parse(controllerContext.RequestContext.HttpContext.Request.Form["day"]);
            int month = int.Parse(controllerContext.RequestContext.HttpContext.Request.Form["month"]);
            int year = int.Parse(controllerContext.RequestContext.HttpContext.Request.Form["year"]);
            result.Birthday = new DateTime(year, month, day);
            return result;
        }
    }
}
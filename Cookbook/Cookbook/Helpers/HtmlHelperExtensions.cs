using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookbook.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString PlaceHolderTextBox(this HtmlHelper helper, string name, string placeHolder)
        {
            var builder = new TagBuilder("input");
            builder.MergeAttribute("type", "text");
            builder.MergeAttribute("name", name);
            builder.MergeAttribute("placeholder", placeHolder);
            return MvcHtmlString.Create((builder.ToString(TagRenderMode.SelfClosing)));
        }
    }
}
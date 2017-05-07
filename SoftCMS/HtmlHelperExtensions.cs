using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftCMS
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Submit(
            this HtmlHelper htmlHelper,
            string text = "送出",
            object htmlAttributes = null)
        {
            var tag = new TagBuilder("input");
            tag.Attributes.Add("type", "submit");
            tag.Attributes.Add("value", text);

            if(htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tag.MergeAttributes(attributes);
            }
            var html = tag.ToString();
            return MvcHtmlString.Create(html);
        }
    }
}
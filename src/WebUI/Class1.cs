﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace WebUI.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static string PageLinks(this HtmlHelper html, int currentPage, int totalPages, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= totalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == currentPage) tag.AddCssClass("selected");

                result.Append(tag.ToString());
            }

            return result.ToString();
        }
    }
}

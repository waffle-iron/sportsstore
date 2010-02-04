using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using System.Web.Mvc;
using WebUI.HtmlHelpers;

namespace Tests
{
    [Subject("PageLinks")]
    public class when_calling_page_links
    {
        static string actualPageLink;

        Because when = () => actualPageLink = ((HtmlHelper)null).PageLinks(2, 3, i => "Page" + i);

        It should_return_expected_page_link =
            () => actualPageLink.ShouldEqual<string>(@"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");
    }
}

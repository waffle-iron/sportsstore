using System;
using System.Linq;
using System.Text;
using DomainModel.Concrete;
using System.Web.Mvc;

namespace Tests
{
    public static class TestExtensions
    {
        public static ViewResult is_a_view_and(this ActionResult result)
        {
            return result as ViewResult;
        }
    }
}

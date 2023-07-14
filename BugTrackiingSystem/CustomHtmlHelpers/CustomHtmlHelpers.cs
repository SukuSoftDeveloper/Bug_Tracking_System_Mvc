using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace BugTrackiingSystem.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        public static MvcHtmlString Show(this MvcHtmlString value, bool condition)
        {
            return condition ? value : MvcHtmlString.Empty;
        }
    }
}
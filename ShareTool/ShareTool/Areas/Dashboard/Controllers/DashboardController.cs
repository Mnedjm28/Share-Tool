using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareTool.Areas.Dashboard.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        [Authorize(Roles ="Admin")]
        public ContentResult Index()
        {
            return Content("Dashboard");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GL.Web.Controllers.Dispatcher
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index()
        {
            return View("~/Views/Dispatcher/Route/Index.cshtml");
        }
    }
}
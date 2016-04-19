using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GL.Web.Controllers.Dispatcher
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View("~/Views/Dispatcher/Staff/Index.cshtml");
        }
    }
}
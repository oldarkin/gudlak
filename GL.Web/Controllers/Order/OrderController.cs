using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GL.Web.Controllers.Dispatcher
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View("~/Views/Dispatcher/Order/Index.cshtml");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GL.Web.Controllers.Dispatcher
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View("~/Views/Dispatcher/Customer/Index.cshtml");
        }
    }
}
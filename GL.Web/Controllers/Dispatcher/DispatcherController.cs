using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GL.Web.Controllers.Dispatcher
{
    public class DispatcherController : Controller
    {
        // GET: Dispatcher
        public ActionResult Index()
        {
            ViewBag.Title = "Диспетчер № 1";
            Guid gd = new Guid();
            return View();
        }
    }
}
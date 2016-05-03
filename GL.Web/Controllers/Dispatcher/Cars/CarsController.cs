using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json;

namespace GL.Web.Controllers.Dispatcher
{
    [JsonRequestBehavior]
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Index()
        {
            return View("~/Views/Dispatcher/Cars/Index.cshtml");
        }

        [HttpGet]
        public async Task<ActionResult> GetCarsFullList()
        {
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GL.Web.Data;

namespace GL.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new gudlakEntities1())
            {
                var data = context.CarsType.ToList();
                Guid gd = new Guid();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
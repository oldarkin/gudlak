using GL.Model;
using DAL=GL.DAL;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GL.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            DAL.CarsType ct = new DAL.CarsType();

            var ctList = ct.GetAll();

            var ctCur = ct.GetByID<CarsType>().Where(data => data.Id == 1);

            CarsType newCT = new CarsType();
            newCT.Id = 0;
            newCT.Name = "asda1212sdasdasd";

            ct.Insert(newCT);

            Guid gd = new Guid();

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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json;
using GL.Web.Data;
using GL.Model;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace GL.Web.Controllers.Dispatcher
{
    [JsonRequestBehavior]
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Index()
        {
            PopulateCarsType();
            return View();
        }

        public ActionResult CarsRead([DataSourceRequest]DataSourceRequest request)
        {
            var cars = GetCars();
            return Json(cars.ToDataSourceResult(request));
        }

        public ActionResult CarsTypeRead([DataSourceRequest]DataSourceRequest request)
        {
            var carsType = GetCarsType();
            return Json(carsType.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CarsCreate([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CarsView> cars)
        {
            var results = new List<CarsView>();

            if (cars != null && ModelState.IsValid)
            {
                using (var context = new gudlakEntities1())
                {
                    foreach (var car in cars)
                    {
                        Cars newCar = new Cars();
                        newCar.id = -1;

                        newCar.name = car.Name;
                        newCar.manufacturer = car.Manufacturer;
                        newCar.reg_number = car.RegNumber;
                        newCar.reg_number_region = car.RegNumberRegion;
                        newCar.garage_number = car.GarageNumber;
                        newCar.carstypeid = car.CarsType.CarsTypeId;


                        var addedCar = context.Cars.Add(newCar);
                        car.CarsId = addedCar.id;

                        results.Add(car);
                    }

                    context.SaveChanges();
                }

            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CarsUpdate([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CarsView> cars)
        {
            if (cars != null && ModelState.IsValid)
            {
                using (var context = new gudlakEntities1())
                {
                    foreach (var car in cars)
                    {
                        var curent = context.Cars.SingleOrDefault(data => data.id == car.CarsId);
                        if (curent != null)
                        {
                            curent.name = car.Name;
                            curent.manufacturer = car.Manufacturer;
                            curent.reg_number = car.RegNumber;
                            curent.reg_number_region = car.RegNumberRegion;
                            curent.garage_number = car.GarageNumber;
                            curent.carstypeid = car.CarsType.CarsTypeId;

                            context.SaveChanges();
                        }
                    }
                }

            }

            return Json(cars.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CarsDelete([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")]IEnumerable<CarsView> cars)
        {
            using (var context = new gudlakEntities1())
            {
                foreach (var car in cars)
                {
                    Cars st = new Cars() { id = car.CarsId };
                    context.Cars.Attach(st);
                    context.Cars.Remove(st);
                    context.SaveChanges();

                }
            }

            return Json(cars.ToDataSourceResult(request, ModelState));
        }

        private static IEnumerable<CarsView> GetCars()
        {
            var context = new gudlakEntities1();
            return context.Cars.Select(data => new CarsView
                {
                    CarsId = data.id,
                    Name = data.name,
                    Manufacturer = data.manufacturer,
                    RegNumber = data.reg_number,
                    RegNumberRegion = data.reg_number_region,
                    GarageNumber = data.garage_number,
                    CarsTypeId = data.carstypeid,
                    CarsType = new CarsTypeView()
                    {
                        CarsTypeId = data.CarsType.id,
                        Name = data.CarsType.name
                    }
                }
            );

        }


        private static IEnumerable<CarsTypeView> GetCarsType()
        {
            var context = new gudlakEntities1();
            return context.CarsType.Select(data => new CarsTypeView
            {
                CarsTypeId = data.id,
                Name = data.name
            });
        }

        private void PopulateCarsType()
        {
            var dataContext = new gudlakEntities1();
            var carsType = dataContext.CarsType
                        .Select(c => new CarsTypeView
                        {
                            CarsTypeId = c.id,
                            Name = c.name
                        })
                        .OrderBy(e => e.Name);

            ViewData["carstype"] = carsType;
            ViewData["defaultcarstype"] = carsType.First();
        }
    }
}
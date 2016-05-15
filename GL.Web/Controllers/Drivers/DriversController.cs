using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GL.Web.Data;
using GL.Model;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace GL.Web.Controllers.Dispatcher
{
    public class DriversController : Controller
    {
        // GET: Drivers
        public ActionResult Index()
        {
            PopulateCars();
            return View();
        }

        public ActionResult DriversRead([DataSourceRequest]DataSourceRequest request)
        {
            var drivers = GetDrivers();
            return Json(drivers.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DriverCreate([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")]IEnumerable<DriversView> drivers)
        {
            var results = new List<DriversView>();

            if (drivers != null && ModelState.IsValid)
            {
                using (var context = new gudlakEntities1())
                {
                    foreach (var driver in drivers)
                    {
                        Drivers d = new Drivers();
                        d.id = -1;
                        d.surname = driver.Surname;
                        d.name = driver.Name;
                        d.patronymic = driver.Patronymic;
                        d.birthday = driver.DateBirth;
                        d.tab_number = driver.TabNumber;
                        d.prava = driver.PravaNum;
                        d.prava_deistvie_do = driver.PraveDataPo;
                        d.passport_ser = driver.PassportSer;
                        d.passport_num = driver.PassportNum;
                        d.passport_info = driver.PassportInfo;

                        var addedDriver = context.Drivers.Add(d);
                        driver.DriversId = addedDriver.id;

                        foreach (var item in driver.Cars)
                        {
                            CarsToDrivers newcd = new CarsToDrivers();
                            newcd.id = -1;
                            newcd.Cars = context.Cars.SingleOrDefault(data => data.id == item.CarsId);
                            newcd.carsid = item.CarsId;

                            newcd.Drivers = addedDriver;
                            newcd.driversid = addedDriver.id;

                            addedDriver.CarsToDrivers.Add(newcd);
                        }

                        results.Add(driver);
                    }

                    context.SaveChanges();
                }

            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DriverUpdate([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")]IEnumerable<DriversView> drivers)
        {
            if (drivers != null)
            {
                using (var context = new gudlakEntities1())
                {
                    foreach (var driver in drivers)
                    {
                        var curent = context.Drivers.SingleOrDefault(data => data.id == driver.DriversId);
                        if (curent != null)
                        {
                            curent.surname = driver.Surname;
                            curent.name = driver.Name;
                            curent.patronymic = driver.Patronymic;
                            curent.birthday = driver.DateBirth;
                            curent.prava = driver.PravaNum;
                            curent.prava_deistvie_do = driver.PraveDataPo;
                            curent.tab_number = driver.TabNumber;
                            curent.passport_ser = driver.PassportSer;
                            curent.passport_num = driver.PassportNum;
                            curent.passport_info = driver.PassportInfo;

                            var existsCarsId = curent.CarsToDrivers.Select(data => data.carsid).ToList();

                            var deletedCars = existsCarsId.Except(driver.Cars.Select(data => data.CarsId).ToList());
                            var newCars = driver.Cars.Select(data => data.CarsId).ToList().Except(existsCarsId);

                            // add new
                            foreach (var item in newCars)
                            {
                                CarsToDrivers newcd = new CarsToDrivers();
                                newcd.id = -1;
                                newcd.Cars = context.Cars.SingleOrDefault(data => data.id == item);
                                newcd.carsid = item;

                                newcd.Drivers = curent;
                                newcd.driversid = curent.id;

                                curent.CarsToDrivers.Add(newcd);
                            }

                            foreach (var item in deletedCars)
                            {
                                var delcd = curent.CarsToDrivers.Where(data => data.carsid == item && data.driversid == curent.id).SingleOrDefault();
                                context.CarsToDrivers.Attach(delcd);
                                context.CarsToDrivers.Remove(delcd);
                            }

                            context.SaveChanges();
                        }
                    }
                }

            }

            return Json(drivers.ToDataSourceResult(request, ModelState));
            //return Json(drivers.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DriverDelete([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")]IEnumerable<DriversView> drivers)
        {
            using (var context = new gudlakEntities1())
            {
                foreach (var driver in drivers)
                {
                    Drivers d = new Drivers() { id = driver.DriversId };
                    context.Drivers.Attach(d);
                    context.Drivers.Remove(d);
                    context.SaveChanges();

                }
            }

            return Json(drivers.ToDataSourceResult(request, ModelState));
        }

        private static IEnumerable<DriversView> GetDrivers()
        {
            var context = new gudlakEntities1();

            return context.Drivers.Select(data => new DriversView
                    {
                        DriversId = data.id,
                        Surname = data.surname,
                        Name = data.name,
                        Patronymic = data.patronymic,
                        PravaNum = data.prava,
                        TabNumber = data.tab_number,
                        DateBirth = data.birthday,
                        PraveDataPo = data.prava_deistvie_do,
                        PassportSer = data.passport_ser,
                        PassportNum = data.passport_num,
                        PassportInfo = data.passport_info,
                        Cars = data.CarsToDrivers.Where(d => d.driversid == data.id)
                                    .Select(d => new CarsView()
                                    {
                                        CarsId = d.carsid,
                                        Name = d.Cars.name,
                                        RegNumber = d.Cars.reg_number,
                                        RegNumberRegion = d.Cars.reg_number_region,
                                        Manufacturer = d.Cars.manufacturer,
                                        GarageNumber = d.Cars.garage_number,
                                        CarsTypeId = d.Cars.carstypeid,
                                        CarsType = new CarsTypeView() { CarsTypeId = d.Cars.CarsType.id, Name = d.Cars.CarsType.name }
                                    })
                    }
                );
        }

        private void PopulateCars()
        {
            var context = new gudlakEntities1();

            var cl = context.Cars.Select(data => new CarsView()
            {
                CarsId = data.id,
                Name = data.name
            });

            ViewData["cars"] = cl;
        }


    }
}
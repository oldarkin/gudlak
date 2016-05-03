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
    public class StaffController : Controller
    {

        // GET: Staff
        public ActionResult Index()
        {
            PopulateCategories();
            return View("~/Views/Dispatcher/Staff/Index.cshtml");
        }

        public ActionResult StaffRead([DataSourceRequest]DataSourceRequest request)
        {
            var staff = GetStaff();
            return Json(staff.ToDataSourceResult(request));
        }

        public ActionResult StaffTypeRead([DataSourceRequest]DataSourceRequest request)
        {
            var staffType = GetStaffType();
            return Json(staffType.ToDataSourceResult(request));
        }

        private static IEnumerable<StaffView> GetStaff()
        {
            var context = new gudlakEntities1();
            return context.Staff.Select(data => new StaffView
                    {
                        StaffId = data.id,
                        Surname = data.surname,
                        Name = data.name,
                        Patronymic = data.patronymic,
                        StaffTypeId = data.StaffType.id,
                        Stafftype = new StaffTypeView
                        {
                            StaffTypeId = data.StaffType.id,
                            Name = data.StaffType.name
                        }
                    }
                );

        }

        private static IEnumerable<StaffTypeView> GetStaffType()
        {
            var context = new gudlakEntities1();
            return context.StaffType.Select(data => new StaffTypeView
            {
                StaffTypeId = data.id,
                Name = data.name
            });
        }

        private void PopulateCategories()
        {
            var dataContext = new gudlakEntities1();
            var stafftype = dataContext.StaffType
                        .Select(c => new StaffTypeView
                        {
                            StaffTypeId = c.id,
                            Name = c.name
                        })
                        .OrderBy(e => e.Name);

            ViewData["stafftype"] = stafftype;
            ViewData["defaultstafftype"] = stafftype.First();
        }
    }
}
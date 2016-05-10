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
            //return View("~/Views/Staff/Index.cshtml");
            return View();
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StaffCreate([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<StaffView> staffs)
        {
            var results = new List<StaffView>();

            if (staffs != null && ModelState.IsValid)
            {
                using (var context = new gudlakEntities1())
                {
                    foreach (var staff in staffs)
                    {
                        Staff newStaff = new Staff();
                        newStaff.id = -1;
                        newStaff.surname = staff.Surname;
                        newStaff.name = staff.Name;
                        newStaff.patronymic = staff.Patronymic;
                        newStaff.stafftypeid = staff.StaffType.StaffTypeId;

                        var addedStaff = context.Staff.Add(newStaff);
                        staff.StaffId = addedStaff.id;

                        results.Add(staff);
                    }

                    context.SaveChanges();
                }

            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Staff_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<StaffView> staffs)
        {
            if (staffs != null && ModelState.IsValid)
            {
                using (var context = new gudlakEntities1())
                {
                    foreach (var staff in staffs)
                    {
                        var curent = context.Staff.SingleOrDefault(data => data.id == staff.StaffId);
                        if (curent != null)
                        {
                            curent.surname = staff.Surname;
                            curent.name = staff.Name;
                            curent.patronymic = staff.Patronymic;
                            curent.stafftypeid = staff.StaffType.StaffTypeId;

                            context.SaveChanges();
                        }
                    }
                }

            }

            return Json(staffs.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StaffDelete([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")]IEnumerable<StaffView> staffs)
        {
            using (var context = new gudlakEntities1())
            {
                foreach (var staff in staffs)
                {
                    Staff st = new Staff() { id = staff.StaffId };
                    context.Staff.Attach(st);
                    context.Staff.Remove(st);
                    context.SaveChanges();
                    
                }
            }

            return Json(staffs.ToDataSourceResult(request, ModelState));
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
                        StaffType = new StaffTypeView
                        {
                            StaffTypeId = data.StaffType.id,
                            Name = data.StaffType.name
                        },
                        StaffTypeId = data.stafftypeid
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
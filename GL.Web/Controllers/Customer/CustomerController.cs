using GL.Model;
using GL.Web.Data;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace GL.Web.Controllers.Dispatcher
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerRead([DataSourceRequest]DataSourceRequest request)
        {
            var customer = GetCustomers();
            return Json(customer.ToDataSourceResult(request));
        }

        private static IEnumerable<CustomerView> GetCustomers()
        {
            var context = new gudlakEntities1();
            return context.Customer.Select(data => new CustomerView
                {
                    CustomerId = data.id,
                    FullName = data.fullname,
                    ShortName = data.shortname,
                    City = data.city,
                    Address = data.fact_address,
                    Zip = data.zip,
                    Phone = data.phone,
                    Inn = data.inn
                }
            );

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CustomerCreate([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CustomerView> customers)
        {
            var results = new List<CustomerView>();

            if (customers != null && ModelState.IsValid)
            {
                using (var context = new gudlakEntities1())
                {
                    foreach (var customer in customers)
                    {
                        Customer newCustomer = new Customer();
                        newCustomer.id = -1;
                        newCustomer.fullname = customer.FullName;
                        newCustomer.shortname = customer.ShortName;
                        newCustomer.city = customer.City;
                        newCustomer.fact_address = customer.Address;
                        newCustomer.zip = customer.Zip;
                        newCustomer.phone = customer.Phone;
                        newCustomer.inn = customer.Inn;

                        var addedCustomer = context.Customer.Add(newCustomer);
                        customer.CustomerId = addedCustomer.id;

                        results.Add(customer);
                    }

                    context.SaveChanges();
                }

            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CustomerUpdate([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CustomerView> customers)
        {
            if (customers != null && ModelState.IsValid)
            {
                using (var context = new gudlakEntities1())
                {
                    foreach (var customer in customers)
                    {
                        var curent = context.Customer.SingleOrDefault(data => data.id == customer.CustomerId);
                        if (curent != null)
                        {
                            curent.fullname = customer.FullName;
                            curent.shortname = customer.ShortName;
                            curent.city = customer.City;
                            curent.fact_address = customer.Address;
                            curent.zip = customer.Zip;
                            curent.phone = customer.Phone;
                            curent.inn = customer.Inn;

                            context.SaveChanges();
                        }
                    }
                }

            }

            return Json(customers.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CustomerDelete([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")]IEnumerable<CustomerView> customers)
        {
            using (var context = new gudlakEntities1())
            {
                foreach (var customer in customers)
                {
                    Customer st = new Customer() { id = customer.CustomerId };
                    context.Customer.Attach(st);
                    context.Customer.Remove(st);
                    context.SaveChanges();

                }
            }

            return Json(customers.ToDataSourceResult(request, ModelState));
        }
    }
}
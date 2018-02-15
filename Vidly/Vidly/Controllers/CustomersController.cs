using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ViewResult Index()
        {
            var customers = this.GetCustomers();

            return View(customers);
        }

        // Get: Customers/Details
        public ActionResult Details(int id)
        {
            var customer = this.GetCustomers().SingleOrDefault(m => m.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id= 1, Name= "Marco Asensio" },
                new Customer { Id= 2, Name= "Julian Draxler" }
            };
        }
    }
}
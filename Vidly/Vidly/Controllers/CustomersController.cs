using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        // Get: Customers/Details
        public ActionResult Details(int id)
        {
            var customer = this._context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(m => m.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}
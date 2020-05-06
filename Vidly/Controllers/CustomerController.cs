using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private MyDBContext _context;

        public CustomerController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerDb.Name = customer.Name;
                customerDb.Birthdate = customer.Birthdate;
                customerDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerDb.MembershipType = customer.MembershipType;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);


            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var customer = customers.FirstOrDefault(n => n.Id == id);

            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }


        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}
using Cable.Data;
using Cable.Models.Customer.Models;
using Cable.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CableMVC.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private CustomerService CreateCustomerService()
        {
            var userId = User.Identity.GetUserId();
            var service = new CustomerService(userId);
            return service;
        }
        // GET: Job
        public ActionResult Index()
        {
            var service = CreateCustomerService();
            var model = service.GetCustomers();

            return View(model);
        }

        // GET: Create Job
        public ActionResult Create()
        {
            ViewData["Jobs"] = _db.Jobs.Select(job => new SelectListItem
            {
                Text = job.JobName,
                Value = job.JobId.ToString()
            });

            return View();
        }

        // POST: Create Job
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Your Job was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Job could not be created");

            return View(model);
        }

        // GET: Customer By Id
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        // GET: Edit 
        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);

            ViewData["Jobs"] = _db.Jobs.Select(job => new SelectListItem
            {
                Text = job.JobName,
                Value = job.JobId.ToString()
            });

            var model =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Address = detail.Address,
                    AccountNumber = detail.AccountNumber
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "ID Mismatch!");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Your customer was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your customer could not be updated!");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Your customer was deleted!";

            return RedirectToAction("Index");
        }


    }
}

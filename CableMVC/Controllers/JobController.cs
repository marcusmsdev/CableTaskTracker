using Cable.Models;
using Cable.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CableMVC.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            var model = service.GetJobs();
        }

        //Add method here 
        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Add code here 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
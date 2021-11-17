using Cable.Models;
using Cable.Models.Job.Models;
using Cable.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CableMVC.Controllers
{
    [Authorize]
    public class JobController : Controller
    {               
            private JobService CreateJobService()
            {
                var userId = User.Identity.GetUserId();
                var service = new JobService(userId);

                return service;
            }
            // GET: Jobs
            public ActionResult Index()
            {
                var service = CreateJobService();
                var model = service.GetJobs();

                return View(model);
            }

            // GET: Create Job
            public ActionResult Create()
            {
                return View();
            }

            // Post: Create Job
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(JobCreate model)
            {
                if (!ModelState.IsValid) return View(model);

                var service = CreateJobService();

                if (service.CreateJob(model))
                {
                    TempData["SaveResult"] = "Job was created!";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Job not created! ");

                return View(model);
            }

            // GET: Job By Id
            public ActionResult Detail(int id)
            {
                var svc = CreateJobService();
                var model = svc.Get(id);

                return View(model);
            }

            //GET: Edit
            public ActionResult Edit(int id)
            {
                var service = CreateJobService();
                var detail = service.Get(id);
                var model =
                    new JobEdit
                    {
                        
                        JobType = detail.JobType,
                        JobDate = detail.JobDate,
                    };

                return View(model);
            }

            // Post Edit
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, JobEdit model)
            {
                if (!ModelState.IsValid) return View(model);

                if (model.JobId != id)
                {
                    ModelState.AddModelError("", "The ID Must remain the same!");
                    return View(model);
                }

                var service = CreateJobService();

                if (service.UpdateJob(model))
                {
                    TempData["SaveResult"] = "Job has updated";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Job not updated!");
                return View();
            }

            public ActionResult Delete(int id)
            {
                var svc = CreateJobService();
                var model = svc.Get(id);

                return View(model);
            }

            [HttpPost]
            [ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeletePost(int id)
            {
                var service = CreateJobService();

                service.Delete(id);

                TempData["SaveResult"] = "Your bookshelf was deleted";

                return RedirectToAction("Index");
            }


        }
    }
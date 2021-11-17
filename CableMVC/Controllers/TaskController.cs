using Cable.Data;
using Cable.Models.Task.Models;
using Cable.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CableMVC.Controllers
{
    public class TaskController : Controller
    {
        [Authorize]
        public class NoteController : Controller
        {
            private ApplicationDbContext _db = new ApplicationDbContext();
            private TaskService CreateTaskService()
            {
                var userId = User.Identity.GetUserId();
                var service = new TaskService(userId);
                return service;
            }

            // GET: Task
            public ActionResult Index()
            {
                var service = CreateTaskService();
                var model = service.GetTasks();

                return View(model);
            }

            // GET: Create Task
            public ActionResult Create()
            {
                ViewData["Tasks"] = _db.Tasks.Select(task => new SelectListItem
                {
                    Text = task.TaskName,
                    Value = task.TaskTotal.ToString()
                });

                return View();
            }

            // POST: Create Task
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(TaskCreate model)
            {
                if (!ModelState.IsValid) return View(model);

                var service = CreateTaskService();

                if (service.CreateTask(model))
                {
                    TempData["SaveResult"] = "Your task was created!";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Task could not be created.");

                return View(model);

            }

            // GET: Task by ID
            [HttpGet]
            public ActionResult Details(int id)
            {
                var svc = CreateTaskService();
                var model = svc.GetTaskById(id);

                return View(model);
            }

            public ActionResult Edit(int id)
            {
                var service = CreateTaskService();
                var detail = service.GetTaskById(id);
                var model =
                    new TaskEdit
                    {
                        TaskId = detail.TaskId,
                        TaskName = detail.TaskName,
                        TaskTotal = detail.TaskTotal
                    };

                return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, TaskEdit model)
            {
                if (!ModelState.IsValid) return View(model);

                if (model.TaskId != id)
                {
                    ModelState.AddModelError("", "ID Mismatch!");
                    return View(model);
                }

                var service = CreateTaskService();

                if (service.UpdateTask(model))
                {
                    TempData["SaveResult"] = "Your task was updated!";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Your task could not be updated!");
                return View();
            }

            public ActionResult Delete(int id)
            {
                var svc = CreateTaskService();
                var model = svc.GetTaskById(id);

                return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteTask(int id)
            {
                var service = CreateTaskService();

                service.DeleteTask(id);

                TempData["SaveResult"] = "Your task was deleted!";

                return RedirectToAction("Index");
            }
        }

    }

}
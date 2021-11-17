using Cable.Data;
using Cable.Models.Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Cable.Services
{
    public class TaskService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string _userId;

        public TaskService(string userId)
        {
            _userId = userId;
        }

        public bool CreateTask(TaskCreate model)
        {
            var entity =
                new Cable.Data.Task()
                {
                    UserId = _userId,
                    TaskName = model.TaskName,
                    TaskTotal = model.TaskTotal

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tasks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TaskListItem> GetTasks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tasks
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                        new TaskListItem
                        {
                            TaskId = e.TaskId,
                            TaskName = e.TaskName,
                            TaskTotal = e.TaskTotal,
                            
                        });

                return query.ToArray();

            }
        }

        public TaskDetail GetTaskById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tasks
                        .Single(e => e.TaskId == id && e.UserId == _userId);

                return
                    new TaskDetail
                    {
                        TaskId = entity.TaskId,
                        TaskName = entity.TaskName,
                        TaskTotal = entity.TaskTotal
                        
                    };
            }
        }

        public bool UpdateTask(TaskEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tasks
                        .Single(e => e.TaskId == model.TaskId && e.UserId == _userId);

                entity.TaskName = model.TaskName;
                entity.TaskTotal = model.TaskTotal;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTask(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Tasks
                    .Single(e => e.TaskId == id && e.UserId == _userId);

                ctx.Tasks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}




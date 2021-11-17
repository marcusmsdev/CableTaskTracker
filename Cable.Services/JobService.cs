using Cable.Data;
using Cable.Models;
using Cable.Models.Job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Services
{
    public class JobService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string _userId;

        public JobService(string userId)
        {
            _userId = userId;
        }

        public bool CreateJob(JobCreate model)
        {
            var entity =
                new Job()
                {
                    UserId = _userId,
                    JobType = model.JobType,
                    JobDate = model.JobDate,
                    CustomerId = model.CustomerId
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Jobs
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobType = e.JobType,
                                    JobId = e.JobId,                                    
                                    JobDate = e.JobDate,
                                    CustomerId = e.CustomerId,
                                });

                return query.ToArray();
            }
        }

        public JobDetail Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var Job =
                    ctx
                    .Jobs
                    .Single(f => f.JobId == id);                

                return 
                    new JobDetail
                {
                    JobId = Job.JobId,
                    CustomerId = Job.CustomerId,
                    JobType = Job.JobType,                    
                    JobDate = Job.JobDate,                    
                };
            }
        }

        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == model.JobId && e.UserId == _userId);

                entity.JobType = model.JobType;
                entity.TaskOrder = model.TaskOrder;
                entity.JobDate = model.JobDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == jobId && e.UserId == _userId);

                ctx.Jobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

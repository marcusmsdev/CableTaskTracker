using Cable.Data;
using Cable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Services
{
    public class JobService
    {

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
                    CustomerName = model.CustomerName,
                    Address = model.Address,
                    AccountNumber = model.AccountNumber,
                    JobDate = model.JobDate,
                    

                };

            
        }
    }
}

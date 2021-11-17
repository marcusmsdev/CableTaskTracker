using Cable.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Models.Job.Models
{
    public class JobDetail
    {
        [Display(Name = "JobID")]
        public int JobId { get; set; }

        [Display(Name = "JobType")]
        public string JobType { get; set; }

        [Display(Name = "JobDate")]
        public DateTime JobDate { get; set; }
        public TaskType TaskOrder { get; set; }

        public int CustomerId { get; set; }


    }
}

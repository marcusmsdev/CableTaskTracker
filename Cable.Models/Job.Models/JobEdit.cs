using Cable.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Models.Job.Models
{
    public class JobEdit
    {
        public string JobType { get; set; }        
        public int JobId { get; set; }
        public DateTime JobDate { get; set; }
        public TaskType TaskOrder { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Models.Job.Models
{
    public class JobListItem
    {
        public int JobId { get; set; }
        public string JobType { get; set; }
        public int CustomerId { get; set; }
        public DateTime JobDate { get; set; }
    }
}

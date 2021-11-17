using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Models.Task.Models
{
    public class TaskCreate
    {        
        public string TaskName { get; set; }        
        public int TaskTotal { get; set; }         
        public int JobbId { get; set; }
    }
}

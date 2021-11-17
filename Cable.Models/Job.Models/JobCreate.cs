using Cable.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Models
{
    public class JobCreate
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime JobDate { get; set; }

        [Required]
        public string JobType { get; set; }

        public TaskType TaskOrder { get; set; }






    }
}

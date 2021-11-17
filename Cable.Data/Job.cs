using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }        
        public string JobName { get; set; }
        public string JobType { get; set; }
        public int AccountNumber { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }        
        public TaskType TaskOrder { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public DateTime JobDate { get; set; }
    }
}

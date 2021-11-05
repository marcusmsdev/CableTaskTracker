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

        [Required]
        public string CustomerName { get; set; }
        public string Address { get; set; }

        [Required]
        public int AccountNumber { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}

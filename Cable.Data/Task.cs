using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Data
{
    public enum TaskType { Empty ,CableBoxInstall, ModemInstall, NewOutlet, Wallfish, ActivateBox, ServiceCall }
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        public TaskType TaskOrder { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required]
        public int TaskTotal { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }         
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
    }

    
}

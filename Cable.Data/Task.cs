using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Data
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public int TaskName { get; set; }

        [Required]
        public int TaskTotal { get; set; }

        [Required]
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }

        public virtual Job Job { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }


    }
}

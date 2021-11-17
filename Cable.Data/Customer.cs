using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }        

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }        
        
        public int PhoneNumber { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }        
        

    }
}

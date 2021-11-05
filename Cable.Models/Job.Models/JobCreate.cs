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
        public string CustomerName { get; set; }
        public string Address { get; set; }

        [Required]
        public int AccountNumber { get; set; }

        [Required]
        public DateTime JobDate { get; set; }

        [Required]





    }
}

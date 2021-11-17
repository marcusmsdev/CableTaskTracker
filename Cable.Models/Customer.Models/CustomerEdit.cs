using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cable.Models.Customer.Models
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public int AccountNumber { get; set; }

        public int JobId { get; set; }
    }
}

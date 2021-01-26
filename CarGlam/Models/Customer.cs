using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarGlam.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerFName { get; set; } // customer first name
        public string CustomerLName { get; set; } // customer last name

        public string Address { get; set; } // customer address
       
        public string Phone { get; set; }// customer phone number



    }
}

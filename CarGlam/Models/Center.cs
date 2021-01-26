using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarGlam.Models
{
    public class Center
    {
        // CarGlam center details
        [Key]
        public int CenterID { get; set; } // creating id for the table
       
        public string CenterName { get; set; } //  enter each center name here
        
        public string Address { get; set; } // enter each center address here

        [DataType(DataType.Date)]
        public DateTime OpeningDate { get; set; } //  opening date of ech center
      
    }
}

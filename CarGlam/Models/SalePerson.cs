using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarGlam.Models
{
    public class SalePerson
    {
        [Key]
        
        public int SalePersonId { get; set; } // sale person foreign key
        public string SalePersonsName { get; set; } // staff member name who sale car
        public double AgreedAmount { get; set; } // agreed amount on car sale

        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; } // date of sale

    }
}

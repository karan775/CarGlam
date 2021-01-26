using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarGlam.Models
{
    public class CarSale
    {
        [Key]
        public int ID { get; set; }//foreign key
        public int CustomerID { get; set; }// foreign key for customer name
        public Customer Customer { get; set; }


        public int SalePersonID { get; set; }//foreign key
        public SalePerson SalePerson { get; set; }// foreign key of sale holder


    }
}

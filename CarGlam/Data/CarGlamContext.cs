using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarGlam.Models;

namespace CarGlam.Data
{
    public class CarGlamContext : DbContext
    {
        public CarGlamContext (DbContextOptions<CarGlamContext> options)
            : base(options)
        {
        }

        public DbSet<CarGlam.Models.Customer> Customer { get; set; }

        public DbSet<CarGlam.Models.SalePerson> SalePerson { get; set; }

        public DbSet<CarGlam.Models.Center> Center { get; set; }

        public DbSet<CarGlam.Models.CarSale> CarSale { get; set; }
    }
}

using AcademyG.Week8Test.Ristorante.Core.Models;
using AcademyG.Week8Test.Ristorante.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.EF
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<User> Users { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MenuConfiguration());
            builder.ApplyConfiguration(new PlateConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}

using AcademyG.Week8Test.Ristorante.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.EF.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.NameMenu)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(m => m.Plates).WithOne(m => m.Menu);

            builder.HasData(
                
                new Menu
                {
                    Id = 1,
                    NameMenu = "Menu di Natale"
                },
                new Menu
                {
                    Id = 2,
                    NameMenu = "Menu di Pasqua"
                },
                new Menu
                {
                    Id = 3,
                    NameMenu = "Menu"
                },
                new Menu
                {
                    Id = 4,
                    NameMenu = "Menu Estivo"
                }
                );
        }
    }
}

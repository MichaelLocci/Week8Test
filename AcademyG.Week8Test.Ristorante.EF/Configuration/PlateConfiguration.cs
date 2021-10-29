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
    public class PlateConfiguration : IEntityTypeConfiguration<Plate>
    {
        public void Configure(EntityTypeBuilder<Plate> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NamePlate)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.TypePlate)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.MenuId)
                .IsRequired();

            builder.HasOne(m => m.Menu).WithMany(p => p.Plates);

            builder.HasData(
                new Plate
                {
                    Id = 1,
                    NamePlate = "Carbonara",
                    Description = "Uova, Pepe, Guanciale, Pecorino",
                    TypePlate = TypePlate.First,
                    Price = 7.30M,
                    MenuId = 3
                },
                new Plate
                {
                    Id = 2,
                    NamePlate = "Gnocchi",
                    Description = "Gnocchi al sugo di Cinghiale",
                    TypePlate = TypePlate.First,
                    Price = 9.50M,
                    MenuId = 1
                },
                new Plate
                {
                    Id = 3,
                    NamePlate = "Bistecca",
                    Description = "Bistecca di Angus",
                    TypePlate = TypePlate.Second,
                    Price = 10.30M,
                    MenuId = 3
                },
                new Plate
                {
                    Id = 4,
                    NamePlate = "Tiramisu",
                    Description = "Uova, savoiardi, caffe, mascarpone",
                    TypePlate = TypePlate.Dessert,
                    Price = 4.30M,
                    MenuId = 1
                },
                new Plate
                {
                    Id = 5,
                    NamePlate = "Pasta con gli asparagi",
                    Description = "asparagi",
                    TypePlate = TypePlate.First,
                    Price = 6.30M,
                    MenuId = 2
                },
                new Plate
                {
                    Id = 6,
                    NamePlate = "Patate al forno",
                    Description = "patate fresce fatte al forno",
                    TypePlate = TypePlate.Side,
                    Price = 4.30M,
                    MenuId = 4
                }
                ) ;
        }
    }
}

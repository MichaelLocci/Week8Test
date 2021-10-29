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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.Role)
                .IsRequired();

            builder.HasData(
                new User
                {
                    Id = 1,
                    Email = "mario.rossi@gmail.com",
                    Password = "1234",
                    Role = Role.Restorer
                },
                new User
                {
                    Id = 2,
                    Email = "fabio.verdi@gmail.com",
                    Password = "5678",
                    Role = Role.Client
                }
                );
        }
    }
}

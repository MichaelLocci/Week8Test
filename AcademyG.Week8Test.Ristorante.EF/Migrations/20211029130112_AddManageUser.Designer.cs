// <auto-generated />
using AcademyG.Week8Test.Ristorante.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcademyG.Week8Test.Ristorante.EF.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    [Migration("20211029130112_AddManageUser")]
    partial class AddManageUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AcademyG.Week8Test.Ristorante.Core.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameMenu")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameMenu = "Menu di Natale"
                        },
                        new
                        {
                            Id = 2,
                            NameMenu = "Menu di Pasqua"
                        },
                        new
                        {
                            Id = 3,
                            NameMenu = "Menu"
                        },
                        new
                        {
                            Id = 4,
                            NameMenu = "Menu Estivo"
                        });
                });

            modelBuilder.Entity("AcademyG.Week8Test.Ristorante.Core.Models.Plate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("NamePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypePlate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Plates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Uova, Pepe, Guanciale, Pecorino",
                            MenuId = 3,
                            NamePlate = "Carbonara",
                            Price = 7.30m,
                            TypePlate = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Gnocchi al sugo di Cinghiale",
                            MenuId = 1,
                            NamePlate = "Gnocchi",
                            Price = 9.50m,
                            TypePlate = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Bistecca di Angus",
                            MenuId = 3,
                            NamePlate = "Bistecca",
                            Price = 10.30m,
                            TypePlate = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Uova, savoiardi, caffe, mascarpone",
                            MenuId = 1,
                            NamePlate = "Tiramisu",
                            Price = 4.30m,
                            TypePlate = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "asparagi",
                            MenuId = 2,
                            NamePlate = "Pasta con gli asparagi",
                            Price = 6.30m,
                            TypePlate = 0
                        },
                        new
                        {
                            Id = 6,
                            Description = "patate fresce fatte al forno",
                            MenuId = 4,
                            NamePlate = "Patate al forno",
                            Price = 4.30m,
                            TypePlate = 2
                        });
                });

            modelBuilder.Entity("AcademyG.Week8Test.Ristorante.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "mario.rossi@gmail.com",
                            Password = "1234",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "fabio.verdi@gmail.com",
                            Password = "5678",
                            Role = 1
                        });
                });

            modelBuilder.Entity("AcademyG.Week8Test.Ristorante.Core.Models.Plate", b =>
                {
                    b.HasOne("AcademyG.Week8Test.Ristorante.Core.Models.Menu", "Menu")
                        .WithMany("Plates")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

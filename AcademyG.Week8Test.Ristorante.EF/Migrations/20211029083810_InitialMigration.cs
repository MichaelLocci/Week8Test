using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyG.Week8Test.Ristorante.EF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMenu = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePlate = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    TypePlate = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plates_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "NameMenu" },
                values: new object[,]
                {
                    { 1, "Menu di Natale" },
                    { 2, "Menu di Pasqua" },
                    { 3, "Menu" },
                    { 4, "Menu Estivo" }
                });

            migrationBuilder.InsertData(
                table: "Plates",
                columns: new[] { "Id", "Description", "MenuId", "NamePlate", "Price", "TypePlate" },
                values: new object[,]
                {
                    { 2, "Gnocchi al sugo di Cinghiale", 1, "Gnocchi", 9.50m, 0 },
                    { 4, "Uova, savoiardi, caffe, mascarpone", 1, "Tiramisu", 4.30m, 3 },
                    { 5, "asparagi", 2, "Pasta con gli asparagi", 6.30m, 0 },
                    { 1, "Uova, Pepe, Guanciale, Pecorino", 3, "Carbonara", 7.30m, 0 },
                    { 3, "Bistecca di Angus", 3, "Bistecca", 10.30m, 1 },
                    { 6, "patate fresce fatte al forno", 4, "Patate al forno", 4.30m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plates_MenuId",
                table: "Plates",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plates");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderApp.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorMeja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Menu_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Status" },
                values: new object[] { 1, "Completed" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "Status" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "MenusId", "NoOrder", "NomorMeja" },
                values: new object[] { 1, 1, "ABC1", "1" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "MenusId", "NoOrder", "NomorMeja" },
                values: new object[] { 2, 2, "ABC2", "2" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "MenusId", "NoOrder", "NomorMeja" },
                values: new object[] { 3, 1, "ABC3", "3" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenusId",
                table: "Orders",
                column: "MenusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Racism.Data.Migrations
{
    public partial class AddCarsAndUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //1. New columns on the existing AspNetUsers table
            migrationBuilder.AddColumn<bool>(
                name: "IsBuyer",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSeller",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //2. Cars table
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearOfManufacturing = table.Column<int>(type: "int", nullable: false),
                    RangeKm = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Sold = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            //3. UserCars join table
            migrationBuilder.CreateTable(
                name: "UserCars",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCars", x => new { x.UserId, x.CarId });

                    table.ForeignKey(
                        name: "FK_UserCars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_UserCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_CarId",
                table: "UserCars",
                column: "CarId");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "UserCars");
            migrationBuilder.DropTable(name: "Cars");

            migrationBuilder.DropColumn(name: "IsBuyer", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "IsSeller", table: "AspNetUsers");
        }
    }
}
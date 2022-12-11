using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulYönetim.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserClassId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserDersId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserClassId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDersId",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}

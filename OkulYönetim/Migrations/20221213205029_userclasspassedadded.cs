using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulYönetim.Migrations
{
    public partial class userclasspassedadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPassed",
                table: "UserClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { "adminuser123@gmail.com", new byte[] { 29, 72, 91, 139, 190, 66, 142, 210, 181, 69, 201, 16, 68, 83, 49, 177, 185, 183, 61, 15, 150, 130, 60, 63, 251, 85, 100, 179, 223, 201, 235, 2 }, new byte[] { 64, 10, 50, 4, 29, 210, 96, 161, 80, 59, 147, 20, 31, 102, 11, 190, 168, 208, 231, 159, 162, 173, 222, 96, 55, 122, 207, 60, 155, 211, 70, 66, 208, 196, 3, 45, 165, 115, 101, 62, 9, 77, 20, 155, 199, 97, 209, 241, 27, 98, 50, 95, 18, 235, 64, 105, 134, 172, 78, 187, 213, 118, 119, 178 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPassed",
                table: "UserClasses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { "adminuser123>gmail.com", new byte[] { 204, 138, 11, 124, 163, 115, 117, 14, 245, 91, 156, 188, 53, 154, 131, 116, 32, 138, 30, 82, 251, 225, 76, 55, 102, 99, 153, 147, 146, 6, 243, 46 }, new byte[] { 30, 11, 153, 186, 202, 59, 76, 220, 0, 176, 103, 245, 238, 236, 12, 164, 133, 181, 126, 1, 194, 177, 163, 192, 78, 167, 170, 194, 5, 181, 129, 199, 156, 20, 90, 213, 125, 248, 42, 175, 255, 119, 153, 156, 16, 93, 140, 144, 242, 250, 169, 57, 74, 120, 225, 54, 43, 237, 217, 101, 155, 198, 247, 74 } });
        }
    }
}

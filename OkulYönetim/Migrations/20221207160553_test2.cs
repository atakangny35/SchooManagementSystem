using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulYönetim.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "IsActive", "RoleName" },
                values: new object[] { 4, true, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Branch", "Email", "Name", "PasswordHash", "PasswordSalt", "Surname", "UserRoleId" },
                values: new object[] { 10, "Admin", "adminuser123>gmail.com", "AmidnUser", new byte[] { 204, 138, 11, 124, 163, 115, 117, 14, 245, 91, 156, 188, 53, 154, 131, 116, 32, 138, 30, 82, 251, 225, 76, 55, 102, 99, 153, 147, 146, 6, 243, 46 }, new byte[] { 30, 11, 153, 186, 202, 59, 76, 220, 0, 176, 103, 245, 238, 236, 12, 164, 133, 181, 126, 1, 194, 177, 163, 192, 78, 167, 170, 194, 5, 181, 129, 199, 156, 20, 90, 213, 125, 248, 42, 175, 255, 119, 153, 156, 16, 93, 140, 144, 242, 250, 169, 57, 74, 120, 225, 54, 43, 237, 217, 101, 155, 198, 247, 74 }, "AmidnUser", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

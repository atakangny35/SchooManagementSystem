using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulYönetim.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "IsActive", "RoleName" },
                values: new object[] { 4, true, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Branch", "Email", "Name", "PasswordHash", "PasswordSalt", "Surname", "UserRoleId" },
                values: new object[] { 10, "Admin", "adminuser123>gmail.com", "AmidnUser", new byte[] { 104, 175, 144, 217, 152, 23, 62, 70, 168, 1, 41, 91, 80, 177, 170, 29, 242, 73, 79, 152, 250, 21, 244, 196, 209, 247, 6, 213, 241, 243, 169, 129 }, new byte[] { 222, 161, 12, 2, 22, 145, 217, 156, 211, 101, 81, 225, 234, 36, 225, 226, 43, 8, 244, 172, 103, 74, 37, 203, 224, 17, 106, 122, 110, 25, 225, 63, 123, 168, 159, 135, 108, 238, 67, 16, 248, 82, 83, 11, 221, 104, 114, 198, 27, 157, 8, 82, 116, 243, 104, 135, 181, 154, 142, 82, 68, 8, 198, 144 }, "AmidnUser", 4 });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulYönetim.Migrations
{
    public partial class AdminUserAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 104, 175, 144, 217, 152, 23, 62, 70, 168, 1, 41, 91, 80, 177, 170, 29, 242, 73, 79, 152, 250, 21, 244, 196, 209, 247, 6, 213, 241, 243, 169, 129 }, new byte[] { 222, 161, 12, 2, 22, 145, 217, 156, 211, 101, 81, 225, 234, 36, 225, 226, 43, 8, 244, 172, 103, 74, 37, 203, 224, 17, 106, 122, 110, 25, 225, 63, 123, 168, 159, 135, 108, 238, 67, 16, 248, 82, 83, 11, 221, 104, 114, 198, 27, 157, 8, 82, 116, 243, 104, 135, 181, 154, 142, 82, 68, 8, 198, 144 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 157, 10, 186, 145, 46, 123, 200, 233, 78, 44, 221, 218, 226, 183, 249, 222, 243, 196, 97, 254, 154, 49, 233, 125, 137, 137, 255, 247, 37, 27, 28, 170 }, new byte[] { 22, 241, 41, 162, 20, 66, 92, 54, 41, 37, 46, 233, 95, 202, 5, 143, 235, 132, 204, 182, 102, 70, 152, 60, 185, 98, 151, 75, 206, 83, 84, 72, 135, 153, 64, 105, 166, 17, 140, 40, 197, 63, 173, 197, 8, 242, 53, 200, 54, 163, 237, 142, 247, 89, 14, 170, 178, 115, 100, 80, 27, 28, 98, 77 } });
        }
    }
}

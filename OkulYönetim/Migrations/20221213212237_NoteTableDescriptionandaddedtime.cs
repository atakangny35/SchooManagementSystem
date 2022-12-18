using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulYönetim.Migrations
{
    public partial class NoteTableDescriptionandaddedtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedTime",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 145, 10, 31, 24, 223, 145, 93, 165, 163, 192, 1, 81, 43, 68, 62, 65, 237, 192, 231, 85, 130, 9, 63, 154, 187, 152, 171, 19, 144, 137, 70, 134 }, new byte[] { 118, 161, 252, 50, 78, 157, 242, 151, 31, 67, 204, 26, 241, 6, 192, 133, 197, 117, 69, 192, 221, 22, 238, 226, 120, 237, 147, 154, 144, 175, 209, 50, 62, 4, 231, 61, 253, 125, 40, 114, 131, 90, 204, 239, 38, 22, 16, 146, 100, 164, 240, 78, 232, 108, 110, 56, 82, 168, 35, 22, 233, 142, 177, 187 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedTime",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Notes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 29, 72, 91, 139, 190, 66, 142, 210, 181, 69, 201, 16, 68, 83, 49, 177, 185, 183, 61, 15, 150, 130, 60, 63, 251, 85, 100, 179, 223, 201, 235, 2 }, new byte[] { 64, 10, 50, 4, 29, 210, 96, 161, 80, 59, 147, 20, 31, 102, 11, 190, 168, 208, 231, 159, 162, 173, 222, 96, 55, 122, 207, 60, 155, 211, 70, 66, 208, 196, 3, 45, 165, 115, 101, 62, 9, 77, 20, 155, 199, 97, 209, 241, 27, 98, 50, 95, 18, 235, 64, 105, 134, 172, 78, 187, 213, 118, 119, 178 } });
        }
    }
}

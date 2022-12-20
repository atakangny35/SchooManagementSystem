using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulYönetim.Migrations
{
    public partial class MessagesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSended = table.Column<bool>(type: "bit", nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    SenderUserId = table.Column<int>(type: "int", nullable: true),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    ReceiverUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverUserId",
                        column: x => x.ReceiverUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderUserId",
                        column: x => x.SenderUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 168, 206, 32, 134, 31, 79, 15, 101, 221, 17, 201, 24, 247, 144, 9, 106, 42, 211, 245, 17, 25, 233, 147, 112, 42, 132, 126, 17, 197, 134, 183, 179 }, new byte[] { 26, 123, 201, 224, 218, 106, 229, 129, 24, 94, 22, 42, 223, 68, 144, 77, 250, 121, 189, 229, 120, 154, 165, 99, 144, 117, 184, 184, 163, 4, 250, 98, 174, 219, 43, 113, 98, 194, 130, 224, 239, 54, 159, 120, 242, 151, 95, 117, 129, 116, 146, 26, 84, 209, 255, 219, 89, 153, 101, 239, 51, 90, 166, 127 } });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverUserId",
                table: "Messages",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderUserId",
                table: "Messages",
                column: "SenderUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 145, 10, 31, 24, 223, 145, 93, 165, 163, 192, 1, 81, 43, 68, 62, 65, 237, 192, 231, 85, 130, 9, 63, 154, 187, 152, 171, 19, 144, 137, 70, 134 }, new byte[] { 118, 161, 252, 50, 78, 157, 242, 151, 31, 67, 204, 26, 241, 6, 192, 133, 197, 117, 69, 192, 221, 22, 238, 226, 120, 237, 147, 154, 144, 175, 209, 50, 62, 4, 231, 61, 253, 125, 40, 114, 131, 90, 204, 239, 38, 22, 16, 146, 100, 164, 240, 78, 232, 108, 110, 56, 82, 168, 35, 22, 233, 142, 177, 187 } });
        }
    }
}

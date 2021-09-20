using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "userLogHistory",
                columns: table => new
                {
                    userLogHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userLogHistory", x => x.userLogHistory);
                    table.ForeignKey(
                        name: "FK_userLogHistory_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userLogHistory_userId",
                table: "userLogHistory",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userLogHistory");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}

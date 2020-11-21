using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leonov.BugTracker.Domain.Database.SqlServer.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    About = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Login = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HashPassword = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    CookieSession = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: true),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_user_type_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "user_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_in_project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_in_project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_in_project_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_in_project_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_Login",
                table: "user",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_UserTypeId",
                table: "user",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_in_project_ProjectId",
                table: "user_in_project",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_user_in_project_UserId",
                table: "user_in_project",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_in_project");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_type");
        }
    }
}

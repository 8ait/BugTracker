using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leonov.BugTracker.Domain.Database.SqlServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "arm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "error_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_error_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "origin_area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_origin_area", x => x.Id);
                });

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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmUserType",
                columns: table => new
                {
                    ArmsId = table.Column<int>(type: "int", nullable: false),
                    UserTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmUserType", x => new { x.ArmsId, x.UserTypesId });
                    table.ForeignKey(
                        name: "FK_ArmUserType_arm_ArmsId",
                        column: x => x.ArmsId,
                        principalTable: "arm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmUserType_user_type_UserTypesId",
                        column: x => x.UserTypesId,
                        principalTable: "user_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
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
                name: "error",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    About = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    ErrorStatusId = table.Column<int>(type: "int", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_error", x => x.Id);
                    table.ForeignKey(
                        name: "FK_error_error_status_ErrorStatusId",
                        column: x => x.ErrorStatusId,
                        principalTable: "error_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_error_origin_area_OriginId",
                        column: x => x.OriginId,
                        principalTable: "origin_area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_error_user_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_error_user_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "user",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "audit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    About = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorStatusId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_audit_error_ErrorId",
                        column: x => x.ErrorId,
                        principalTable: "error",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_audit_error_status_ErrorStatusId",
                        column: x => x.ErrorStatusId,
                        principalTable: "error_status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_audit_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commentary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_commentary_commentary_ParentId",
                        column: x => x.ParentId,
                        principalTable: "commentary",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_commentary_error_ErrorId",
                        column: x => x.ErrorId,
                        principalTable: "error",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commentary_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmUserType_UserTypesId",
                table: "ArmUserType",
                column: "UserTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_audit_ErrorId",
                table: "audit",
                column: "ErrorId");

            migrationBuilder.CreateIndex(
                name: "IX_audit_ErrorStatusId",
                table: "audit",
                column: "ErrorStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_audit_UserId",
                table: "audit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_commentary_ErrorId",
                table: "commentary",
                column: "ErrorId");

            migrationBuilder.CreateIndex(
                name: "IX_commentary_ParentId",
                table: "commentary",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_commentary_UserId",
                table: "commentary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_error_CreateUserId",
                table: "error",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_error_ErrorStatusId",
                table: "error",
                column: "ErrorStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_error_OriginId",
                table: "error",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_error_ResponsibleUserId",
                table: "error",
                column: "ResponsibleUserId");

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
                name: "ArmUserType");

            migrationBuilder.DropTable(
                name: "audit");

            migrationBuilder.DropTable(
                name: "commentary");

            migrationBuilder.DropTable(
                name: "user_in_project");

            migrationBuilder.DropTable(
                name: "arm");

            migrationBuilder.DropTable(
                name: "error");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "error_status");

            migrationBuilder.DropTable(
                name: "origin_area");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_type");
        }
    }
}

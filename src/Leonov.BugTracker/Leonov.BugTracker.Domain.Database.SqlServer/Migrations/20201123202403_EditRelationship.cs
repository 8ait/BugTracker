using Microsoft.EntityFrameworkCore.Migrations;

namespace Leonov.BugTracker.Domain.Database.SqlServer.Migrations
{
    public partial class EditRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_error_user_CreateUserId",
                table: "error");

            migrationBuilder.DropForeignKey(
                name: "FK_error_user_ResponsibleUserId",
                table: "error");

            migrationBuilder.AddForeignKey(
                name: "FK_error_user_in_project_CreateUserId",
                table: "error",
                column: "CreateUserId",
                principalTable: "user_in_project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_error_user_in_project_ResponsibleUserId",
                table: "error",
                column: "ResponsibleUserId",
                principalTable: "user_in_project",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_error_user_in_project_CreateUserId",
                table: "error");

            migrationBuilder.DropForeignKey(
                name: "FK_error_user_in_project_ResponsibleUserId",
                table: "error");

            migrationBuilder.AddForeignKey(
                name: "FK_error_user_CreateUserId",
                table: "error",
                column: "CreateUserId",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_error_user_ResponsibleUserId",
                table: "error",
                column: "ResponsibleUserId",
                principalTable: "user",
                principalColumn: "Id");
        }
    }
}

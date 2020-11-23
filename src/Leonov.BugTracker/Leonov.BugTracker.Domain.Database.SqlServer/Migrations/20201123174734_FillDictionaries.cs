using Microsoft.EntityFrameworkCore.Migrations;

namespace Leonov.BugTracker.Domain.Database.SqlServer.Migrations
{
    public partial class FillDictionaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("arm", new[] { "Name" }, new[] { "create_project" });
            migrationBuilder.InsertData("arm", new[] { "Name" }, new[] { "edit_project" });
            migrationBuilder.InsertData("arm", new[] { "Name" }, new[] { "delete_project" });
            migrationBuilder.InsertData("arm", new[] { "Name" }, new[] { "create_error" });
            migrationBuilder.InsertData("arm", new[] { "Name" }, new[] { "edit_error" });
            migrationBuilder.InsertData("arm", new[] { "Name" }, new[] { "delete_error" });
            migrationBuilder.InsertData("arm", new[] { "Name" }, new[] { "edit_status_error" });

            migrationBuilder.InsertData("user_type", new[] { "Name" }, new[] { "Руководитель проекта" });
            migrationBuilder.InsertData("user_type", new[] { "Name" }, new[] { "Тестировщик" });
            migrationBuilder.InsertData("user_type", new[] { "Name" }, new[] { "Разработчик" });

            migrationBuilder.InsertData("error_status", new[] { "Name", "IsActive" }, new object[] { "Обнаружено", true });
            migrationBuilder.InsertData("error_status", new[] { "Name", "IsActive" }, new object[] { "В процессе исправления", true });
            migrationBuilder.InsertData("error_status", new[] { "Name", "IsActive" }, new object[] { "Отложено", true });
            migrationBuilder.InsertData("error_status", new[] { "Name", "IsActive" }, new object[] { "На тестировании", true });
            migrationBuilder.InsertData("error_status", new[] { "Name", "IsActive" }, new object[] { "Исправлено", false });
            migrationBuilder.InsertData("error_status", new[] { "Name", "IsActive" }, new object[] { "Закрыто", false });
            migrationBuilder.InsertData("error_status", new[] { "Name", "IsActive" }, new object[] { "Нем может быть исправлено", false });
            migrationBuilder.InsertData("error_status", new[] { "Name", "IsActive" }, new object[] { "Не является ошибкой", false });

            migrationBuilder.InsertData("origin_area", new[] { "Name" }, new[] { "Документация" });
            migrationBuilder.InsertData("origin_area", new[] { "Name" }, new[] { "Слой данных" });
            migrationBuilder.InsertData("origin_area", new[] { "Name" }, new[] { "Слой бизнес логики" });
            migrationBuilder.InsertData("origin_area", new[] { "Name" }, new[] { "Слой отображения" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoAppApi.Migrations
{
    public partial class inititalseeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mission 1" });

            migrationBuilder.InsertData(
                table: "todos",
                columns: new[] { "Id", "IsComplete", "Name" },
                values: new object[] { 2, true, "Mission 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "todos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

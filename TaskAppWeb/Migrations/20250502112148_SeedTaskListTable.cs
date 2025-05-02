using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskAppWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedTaskListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskLists",
                columns: new[] { "Id", "Name", "Priority", "isCompleted" },
                values: new object[,]
                {
                    { 1, "Do Exercise", "High", true },
                    { 2, "Make Dinner", "Medium", false },
                    { 3, "Have Lunch", "Low", false },
                    { 4, "Read", "High", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

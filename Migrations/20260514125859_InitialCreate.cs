using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NeuroHub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AIPrompts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromptText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeuralNetwork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIPrompts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AIPrompts",
                columns: new[] { "Id", "NeuralNetwork", "Price", "PromptText", "Title" },
                values: new object[,]
                {
                    { 1, "ChatGPT", 5m, "Напиши SEO-оптимізовану статтю на тему...", "Створити SEO статтю" },
                    { 2, "Midjourney", 10m, "Створи логотип для IT компанії у стилі...", "Генерація логотипу" },
                    { 3, "ChatGPT", 0m, "Проаналізуй і покращи цей код...", "Рефакторинг коду" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AIPrompts");
        }
    }
}

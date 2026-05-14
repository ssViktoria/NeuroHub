using Microsoft.EntityFrameworkCore;
using NeuroHub.Models;

namespace NeuroHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AIPrompt> AIPrompts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Початкові дані для тесту
            modelBuilder.Entity<AIPrompt>().HasData(
                new AIPrompt { Id = 1, Title = "Створити SEO статтю", PromptText = "Напиши SEO-оптимізовану статтю на тему...", NeuralNetwork = "ChatGPT", Price = 5 },
                new AIPrompt { Id = 2, Title = "Генерація логотипу", PromptText = "Створи логотип для IT компанії у стилі...", NeuralNetwork = "Midjourney", Price = 10 },
                new AIPrompt { Id = 3, Title = "Рефакторинг коду", PromptText = "Проаналізуй і покращи цей код...", NeuralNetwork = "ChatGPT", Price = 0 }
            );
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace NeuroHub.Models
{
    public class AIPrompt
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва обов'язкова")]
        [Display(Name = "Назва промпту")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Текст промпту обов'язковий")]
        [Display(Name = "Текст промпту")]
        [DataType(DataType.MultilineText)]
        public string PromptText { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Нейромережа")]
        public string NeuralNetwork { get; set; } = "ChatGPT"; // ChatGPT, Midjourney, StableDiffusion

        [Display(Name = "Ціна")]
        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } = 0;
    }
}
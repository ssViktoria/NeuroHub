using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NeuroHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Читання змінних для UI
            ViewBag.SystemBanner = _configuration["UI__SystemBanner"] ?? "NeuroHub Platform";
            ViewBag.BuildVersion = _configuration["App__BuildVersion"] ?? "Unknown";

            // Перевірка наявності API ключа
            var apiKey = _configuration["Neuro__ApiKey"];
            ViewBag.NeuroApiKeyExists = !string.IsNullOrEmpty(apiKey) &&
                                         apiKey != "sk-live-super-secret-key-999" &&
                                         apiKey != "";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
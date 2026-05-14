using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeuroHub.Data;
using NeuroHub.Models;

namespace NeuroHub.Controllers
{
    public class AIPromptsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AIPromptsController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private void SetViewBagVariables()
        {
            ViewBag.SystemBanner = _configuration["UI__SystemBanner"] ?? "NeuroHub Platform";
            ViewBag.BuildVersion = _configuration["App__BuildVersion"] ?? "Unknown";
            var apiKey = _configuration["Neuro__ApiKey"];
            ViewBag.NeuroApiKeyExists = !string.IsNullOrEmpty(apiKey) && apiKey != "sk-live-super-secret-key-999" && apiKey != "";
        }

        public async Task<IActionResult> Index()
        {
            SetViewBagVariables();
            return View(await _context.AIPrompts.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            SetViewBagVariables();
            if (id == null) return NotFound();
            var aiPrompt = await _context.AIPrompts.FirstOrDefaultAsync(m => m.Id == id);
            if (aiPrompt == null) return NotFound();
            return View(aiPrompt);
        }

        public IActionResult Create()
        {
            SetViewBagVariables();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,PromptText,NeuralNetwork,Price")] AIPrompt aiPrompt)
        {
            SetViewBagVariables();
            if (ModelState.IsValid)
            {
                _context.Add(aiPrompt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aiPrompt);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            SetViewBagVariables();
            if (id == null) return NotFound();
            var aiPrompt = await _context.AIPrompts.FindAsync(id);
            if (aiPrompt == null) return NotFound();
            return View(aiPrompt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PromptText,NeuralNetwork,Price")] AIPrompt aiPrompt)
        {
            SetViewBagVariables();
            if (id != aiPrompt.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aiPrompt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.AIPrompts.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aiPrompt);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            SetViewBagVariables();
            if (id == null) return NotFound();
            var aiPrompt = await _context.AIPrompts.FirstOrDefaultAsync(m => m.Id == id);
            if (aiPrompt == null) return NotFound();
            return View(aiPrompt);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aiPrompt = await _context.AIPrompts.FindAsync(id);
            if (aiPrompt != null) _context.AIPrompts.Remove(aiPrompt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
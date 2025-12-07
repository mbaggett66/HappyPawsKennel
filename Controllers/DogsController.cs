using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HappyPawsKennel.Data;
using HappyPawsKennel.Models;

namespace HappyPawsKennel.Controllers
{
    public class DogsController : Controller
    {
        private readonly HappyPawsContext _context;
        private readonly ILogger<DogsController> _logger;
        private readonly IDogService _dogService;

        public DogsController(HappyPawsContext context, ILogger<DogsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Dogs
        public async Task<IActionResult> Index()
        {
            var happyPawsContext = _context.Dogs.Include(d => d.Kennel);
            return View(await happyPawsContext.ToListAsync());
        }

        // GET: Dogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Details requested with null ID. CorrelationId={CorrelationId}", HttpContext.TraceIdentifier);
                return NotFound();
            }

            var dog = await _context.Dogs
                .Include(d => d.Kennel)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dog == null)
            {
                _logger.LogWarning("Dog not found. DogId={DogId} CorrelationId={CorrelationId}", id, HttpContext.TraceIdentifier);
                return NotFound();
            }

            _logger.LogInformation("Dog details retrieved successfully. DogId={DogId} CorrelationId={CorrelationId}", id, HttpContext.TraceIdentifier);
            return View(dog);
        }

        // GET: Dogs/Create
        public IActionResult Create()
        {
            ViewData["KennelId"] = new SelectList(_context.Kennels, "Id", "Id");
            return View();
        }

        // POST: Dogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Breed,Age,Weight,OwnerName,KennelId")] Dog dog)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Create failed due to invalid model state. CorrelationId={CorrelationId}", HttpContext.TraceIdentifier);
                ViewData["KennelId"] = new SelectList(_context.Kennels, "Id", "Id", dog.KennelId);
                return View(dog);
            }

            _context.Add(dog);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Dog created successfully. DogId={DogId} Name={Name} CorrelationId={CorrelationId}",
                dog.Id, dog.Name, HttpContext.TraceIdentifier);

            return RedirectToAction(nameof(Index));
        }

        // GET: Dogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }
            ViewData["KennelId"] = new SelectList(_context.Kennels, "Id", "Id", dog.KennelId);
            return View(dog);
        }

        // POST: Dogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Breed,Age,Weight,OwnerName,KennelId")] Dog dog)
        {
            if (id != dog.Id)
            {
                _logger.LogError("Dog edit failed due to ID mismatch. RouteId={RouteId} DogId={DogId} CorrelationId={CorrelationId}",
                    id, dog.Id, HttpContext.TraceIdentifier);
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dog);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Dog edited successfully. DogId={DogId} CorrelationId={CorrelationId}",
                        dog.Id, HttpContext.TraceIdentifier);
                }
                catch (DbUpdateConcurrencyException)
                {
                    _logger.LogError("Concurrency exception while editing dog. DogId={DogId} CorrelationId={CorrelationId}",
                        dog.Id, HttpContext.TraceIdentifier);

                    if (!DogExists(dog.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["KennelId"] = new SelectList(_context.Kennels, "Id", "Id", dog.KennelId);
            return View(dog);
        }

        // GET: Dogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs
                .Include(d => d.Kennel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: Dogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);

            if (dog == null)
            {
                _logger.LogWarning("Delete attempted but dog not found. DogId={DogId} CorrelationId={CorrelationId}",
                    id, HttpContext.TraceIdentifier);
                return NotFound();
            }

            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Dog deleted successfully. DogId={DogId} CorrelationId={CorrelationId}",
                id, HttpContext.TraceIdentifier);

            return RedirectToAction(nameof(Index));
        }

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.Id == id);
        }
        

        public async Task<IActionResult> SearchByBreed(string breed)
        {
            if (string.IsNullOrEmpty(breed))
                return View(new List<Dog>());

            var dogs = await _dogService.GetDogsByBreedAsync(breed);
            return View(dogs);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HappyPawsKennel.Data;
using HappyPawsKennel.Models;

namespace HappyPawsKennel.Pages.Dogs
{
    public class CreateModel : PageModel
    {
        private readonly HappyPawsKennel.Data.HappyPawsContext _context;

        public CreateModel(HappyPawsKennel.Data.HappyPawsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["KennelId"] = new SelectList(_context.Kennels, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Dog Dog { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dogs.Add(Dog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

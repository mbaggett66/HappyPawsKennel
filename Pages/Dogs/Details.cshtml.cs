using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HappyPawsKennel.Data;
using HappyPawsKennel.Models;

namespace HappyPawsKennel.Pages.Dogs
{
    public class DetailsModel : PageModel
    {
        private readonly HappyPawsKennel.Data.HappyPawsContext _context;

        public DetailsModel(HappyPawsKennel.Data.HappyPawsContext context)
        {
            _context = context;
        }

        public Dog Dog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs.FirstOrDefaultAsync(m => m.Id == id);

            if (dog is not null)
            {
                Dog = dog;

                return Page();
            }

            return NotFound();
        }
    }
}

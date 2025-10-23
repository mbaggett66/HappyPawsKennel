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
    public class IndexModel : PageModel
    {
        private readonly HappyPawsKennel.Data.HappyPawsContext _context;

        public IndexModel(HappyPawsKennel.Data.HappyPawsContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Dog = await _context.Dogs
                .Include(d => d.Kennel).ToListAsync();
        }
    }
}

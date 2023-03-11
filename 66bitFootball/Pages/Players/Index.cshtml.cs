using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _66bitFootball.Data;
using _66bitFootball.Models;

namespace _66bitFootball.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly _66bitFootball.Data._66bitFootballContext _context;

        public IndexModel(_66bitFootball.Data._66bitFootballContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Players != null)
            {
                Player = await _context.Players
                .Include(p => p.Team).ToListAsync();
            }
        }
    }
}

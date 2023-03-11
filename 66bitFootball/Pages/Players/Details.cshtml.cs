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
    public class DetailsModel : PageModel
    {
        private readonly _66bitFootball.Data._66bitFootballContext _context;

        public DetailsModel(_66bitFootball.Data._66bitFootballContext context)
        {
            _context = context;
        }

      public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            else 
            {
                Player = player;
            }
            return Page();
        }
    }
}

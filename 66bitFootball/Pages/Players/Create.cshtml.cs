using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _66bitFootball.Data;
using _66bitFootball.Models;
using _66bitFootball.Services;
using System.ComponentModel.DataAnnotations;

namespace _66bitFootball.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly _66bitFootball.Data._66bitFootballContext _context;
        private readonly PlayerService _playerService;
        private readonly TeamService _teamService;

        public CreateModel(_66bitFootball.Data._66bitFootballContext context, PlayerService playerService, TeamService teamService)
        {
            _context = context;
            _playerService = playerService;
            _teamService = teamService;
        }

        

        [BindProperty]
        public Player Player { get; set; }
        public SelectList Teams { get; set; } = new SelectList(new List<SelectListItem>());
        public List<SelectListItem> Genders { get; } = new List<SelectListItem>()
        {
            new SelectListItem
            {
                Value = Gender.Male.ToString(), Text = "муж."
            },
            new SelectListItem
            {
                Value = Gender.Female.ToString(), Text = "жен."
            }
        };

        public List<SelectListItem> Countrys { get; } = new List<SelectListItem>()
        {
            new SelectListItem
            {
                Value = Country.Russia.ToString(), Text = "Россия"
            },
            new SelectListItem
            {
                Value = Country.USA.ToString(), Text = "США"
            },
            new SelectListItem
            {
                Value = Country.Italy.ToString(), Text = "Италия"
            }
        };

        [Display(Name = "Новая команда")]
        public string NewTeamName { get; set; } = "";

        public IActionResult OnGet()
        {
            Teams = new SelectList(_context.Teams, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrWhiteSpace(NewTeamName))
            {
                var newTeamID = await _teamService.CreateTeamFromName(NewTeamName);
                Player.TeamId = newTeamID;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _playerService.CreatePlayer(Player);

            return RedirectToPage("./Index");
        }
    }
}

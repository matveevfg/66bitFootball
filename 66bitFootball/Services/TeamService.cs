using _66bitFootball.Data;
using _66bitFootball.Models;

namespace _66bitFootball.Services
{
    public class TeamService
    {
        private readonly _66bitFootballContext _context;

        public TeamService(_66bitFootballContext context) { _context = context; }

        public async Task<int> CreateTeamFromName(string TeamName)
        {
            var team = new Team
            {
                Name = TeamName
            };
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team.Id;
        }
    }
}

using _66bitFootball.Data;
using _66bitFootball.Models;

namespace _66bitFootball.Services
{
    public class PlayerService
    {
        private readonly _66bitFootballContext _context;

        public PlayerService(_66bitFootballContext context) { _context = context; }

        public async Task CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync(); 
        }
    }
}

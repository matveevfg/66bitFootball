using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _66bitFootball.Models;

namespace _66bitFootball.Data
{
    public class _66bitFootballContext : DbContext
    {
        public _66bitFootballContext (DbContextOptions<_66bitFootballContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; } = default!;
        public DbSet<Team> Teams { get; set; } = default!;
    }
}

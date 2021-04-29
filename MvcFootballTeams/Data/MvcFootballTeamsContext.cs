using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcFootballTeams.Models;

namespace MvcFootballTeams.Data
{
    public class MvcFootballTeamsContext : DbContext
    {
        public MvcFootballTeamsContext (DbContextOptions<MvcFootballTeamsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcFootballTeams.Models.FootballTeam> FootballTeam { get; set; }
    }
}

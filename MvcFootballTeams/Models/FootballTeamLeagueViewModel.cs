using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFootballTeams.Models
{
    public class FootballTeamLeagueViewModel
    {
        public List<FootballTeam> FootballTeams { get; set; }

        public SelectList Leagues { get; set; }

        public string FootballTeamLeague  { get; set; }
        public string SearchString { get; set; }

    }
}

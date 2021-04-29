using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFootballTeams.Models
{
    public class FootballTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        public string League { get; set; }

        [Display(Name="Domestic Rank")]
        public int DomesticRank { get; set; }

        [Display(Name="UEFA Rank")]
        public int UefaRank { get; set; }
        
        public string Value { get; set; }


    }
}

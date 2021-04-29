using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcFootballTeams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFootballTeams.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcFootballTeamsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcFootballTeamsContext>>()))
            {
                if(context.FootballTeam.Any())
                {
                    return;
                }
                context.FootballTeam.AddRange(
                    new FootballTeam
                    {
                        Name = "Dinamo Bucuresti",
                        Founded = DateTime.Parse("1948-05-14"),
                        League = "Liga 1",
                        DomesticRank = 15,
                        UefaRank = 293

                    },
                    new FootballTeam
                      {
                          Name = "FCSB",
                          Founded = DateTime.Parse("1947-06-07"),
                          League = "Liga 1",
                          DomesticRank = 1,
                          UefaRank = 70

                    },

                  new FootballTeam
                  {
                            Name = "Rapid Bucuresti",
                            Founded = DateTime.Parse("1923-07-25"),
                            League = "Liga 2",
                            DomesticRank = 2                            

                  }


                 );

                context.SaveChanges();



            }



        }
    }
}

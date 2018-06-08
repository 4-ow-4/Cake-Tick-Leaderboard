using CakeTickBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CakeTickBoard.Migrations.Seed
{
    public static class SeedRankings
    {
        public static void Seed(ApplicationDbContext context)
        {
            try
            {
                var rankings = GetRankings();

                var dbRankings = context.Rankings.ToList();

                foreach(var rank in rankings)
                {
                    var rankInDb = dbRankings.FirstOrDefault(r => r.RankName == rank.RankName);
                    if(rankInDb == null)
                    {
                        context.Rankings.Add(
                            new CakeRanking()
                            {
                                RankName = rank.RankName,
                                LowerBoundPoints = rank.LowerBoundPoints,
                                UpperBoundPoints = rank.UpperBoundPoints
                            });
                    }
                    else
                    {
                        rankInDb.LowerBoundPoints = rank.LowerBoundPoints;
                        rankInDb.UpperBoundPoints = rank.UpperBoundPoints;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public static IEnumerable<CakeRanking> GetRankings()
        {
            return new List<CakeRanking>()
        {
            new CakeRanking(){ RankName = "Newbie", LowerBoundPoints = 0, UpperBoundPoints = 4 },
            new CakeRanking(){ RankName = "Novice", LowerBoundPoints = 5, UpperBoundPoints = 9 },
            new CakeRanking(){ RankName = "Rookie", LowerBoundPoints = 10, UpperBoundPoints = 14 },
            new CakeRanking(){ RankName = "Beginner", LowerBoundPoints = 15, UpperBoundPoints = 19 },
            new CakeRanking(){ RankName = "Talented", LowerBoundPoints = 20, UpperBoundPoints = 24 },
            new CakeRanking(){ RankName = "Skilled", LowerBoundPoints = 25, UpperBoundPoints = 29 },
            new CakeRanking(){ RankName = "Intermediate", LowerBoundPoints = 30, UpperBoundPoints = 34 },
            new CakeRanking(){ RankName = "Skillful", LowerBoundPoints = 35, UpperBoundPoints = 39 },
            new CakeRanking(){ RankName = "Seasoned", LowerBoundPoints = 40, UpperBoundPoints = 44 },
            new CakeRanking(){ RankName = "Proficient", LowerBoundPoints = 45, UpperBoundPoints = 49 },
            new CakeRanking(){ RankName = "Experienced", LowerBoundPoints = 50, UpperBoundPoints = 54 },
            new CakeRanking(){ RankName = "Advanced", LowerBoundPoints = 55, UpperBoundPoints = 59 },
            new CakeRanking(){ RankName = "Senior", LowerBoundPoints = 60, UpperBoundPoints = 64 },
            new CakeRanking(){ RankName = "Expert", LowerBoundPoints = 65, UpperBoundPoints = int.MaxValue },
        };
        }
    }
}
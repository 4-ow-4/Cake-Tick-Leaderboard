using System;

namespace CakeTickBoard.Models
{
    public class CakeRanking
    {
        public Guid Id { get; set; }
        public string RankName { get; set; }
        public int LowerBoundPoints { get; set; }
        public int UpperBoundPoints { get; set; }
    }
}
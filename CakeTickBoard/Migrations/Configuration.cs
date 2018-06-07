namespace CakeTickBoard.Migrations
{
    using CakeTickBoard.Migrations.Seed;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CakeTickBoard.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CakeTickBoard.Models.ApplicationDbContext";
        }

        protected override void Seed(CakeTickBoard.Models.ApplicationDbContext context)
        {
            SeedRankings.Seed(context);
        }
    }
}

using System.Data.Entity.Migrations;
using System.Linq;

namespace CakeTickBoard.Migrations
{
    public static class DatabaseInitializerHelper
    {
        public static void AutoApplyMigrations(DbMigrator dbMigrator)
        {
            ApplyForwardPendingMigrations(dbMigrator);
            ApplyRollBackMigrations(dbMigrator);
        }

        private static void ApplyForwardPendingMigrations(DbMigrator dbMigrator)
        {
            dbMigrator.Update();
        }

        private static void ApplyRollBackMigrations(DbMigrator dbMigrator)
        {
            var latestMigrationAppliedToDatabase = dbMigrator.GetDatabaseMigrations().OrderBy(x => x).Last();
            var latestMigrationDefinedInCode = dbMigrator.GetLocalMigrations().OrderBy(x => x).Last();

            if (latestMigrationAppliedToDatabase.Equals(latestMigrationDefinedInCode))
                return;


            dbMigrator.Configuration.AutomaticMigrationDataLossAllowed = true;
            dbMigrator.Update(latestMigrationDefinedInCode);
        }
    }
}
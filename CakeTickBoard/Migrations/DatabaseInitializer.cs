using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CakeTickBoard.Migrations
{
    public class DatabaseInitializer : IDatabaseInitializer<DbContext>
    {
        public void InitializeDatabase(DbContext context)
        {
            var dbMigrator = new DbMigrator(new Configuration());
            DatabaseInitializerHelper.AutoApplyMigrations(dbMigrator);
        }
    }
}
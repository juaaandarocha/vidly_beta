namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO movies (Name)
                  VALUES ('X-Men')");

            Sql(@"INSERT INTO movies (Name)
                  VALUES ('Deadpool')");
        }
        
        public override void Down()
        {
        }
    }
}

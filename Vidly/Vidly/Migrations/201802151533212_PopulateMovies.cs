namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO Movies(Name, ReleaseDate, DateAdded, NumberInStock, GenreId)
VALUES ('Hangover', '2009/11/06', '2018/02/15', 5, 5)");

            Sql(@"
INSERT INTO Movies(Name, ReleaseDate, DateAdded, NumberInStock, GenreId)
VALUES ('Die Hard', '1988/12/22', '2018/02/15', 8, 1)");
        }
        
        public override void Down()
        {
        }
    }
}

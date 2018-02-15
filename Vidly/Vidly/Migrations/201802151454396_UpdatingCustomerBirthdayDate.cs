namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingCustomerBirthdayDate : DbMigration
    {
        public override void Up()
        {
            Sql(@"
UPDATE Customers
   SET BirthdayDate = '01/01/1980'
 WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}

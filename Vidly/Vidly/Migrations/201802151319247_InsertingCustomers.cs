namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertingCustomers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId)
                  VALUES ('John Smith', 0, 1)");
            Sql(@"INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId)
                  VALUES ('Mary Williams', 1, 2)");
        }
        
        public override void Down()
        {
        }
    }
}

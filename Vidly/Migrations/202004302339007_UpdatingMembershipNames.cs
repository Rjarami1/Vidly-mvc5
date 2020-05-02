namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingMembershipNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Pay as You Go' WHERE DurationInMonths = 0");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Monthly' WHERE DurationInMonths = 1");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Quarterly' WHERE DurationInMonths = 3");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Yearly' WHERE DurationInMonths = 12");
        }
        
        public override void Down()
        {
        }
    }
}

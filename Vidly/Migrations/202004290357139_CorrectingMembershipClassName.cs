namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectingMembershipClassName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MemebershipTypes", newName: "MembershipTypes");
            DropForeignKey("dbo.Customers", "MemebershipType_Id", "dbo.MemebershipTypes");
            DropIndex("dbo.Customers", new[] { "MemebershipType_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MemebershipType_Id", newName: "MembershipTypeId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MemebershipType_Id");
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemebershipType_Id");
            AddForeignKey("dbo.Customers", "MemebershipType_Id", "dbo.MemebershipTypes", "Id");
            RenameTable(name: "dbo.MembershipTypes", newName: "MemebershipTypes");
        }
    }
}

namespace PlayingWIthEFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxusername : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 25));
            AddPrimaryKey("dbo.Users", "UserName");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "UserName");
        }
    }
}

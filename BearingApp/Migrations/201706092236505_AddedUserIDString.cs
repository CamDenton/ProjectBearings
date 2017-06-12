namespace BearingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIDString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeebaInfoes", "userID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MeebaInfoes", "userID");
        }
    }
}

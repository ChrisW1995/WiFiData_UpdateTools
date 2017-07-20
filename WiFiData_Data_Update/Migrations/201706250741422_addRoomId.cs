namespace WiFiData_Data_Update.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRoomId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.wifi_list", "roomId", c => c.Int(nullable:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.wifi_list", "roomId");
        }
    }
}

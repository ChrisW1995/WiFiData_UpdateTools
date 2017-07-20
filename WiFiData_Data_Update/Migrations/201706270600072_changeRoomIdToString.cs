namespace WiFiData_Data_Update.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeRoomIdToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.wifi_list", "roomId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.wifi_list", "roomId", c => c.Int());
        }
    }
}

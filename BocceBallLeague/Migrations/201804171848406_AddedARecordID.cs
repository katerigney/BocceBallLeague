namespace BocceBallLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedARecordID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Teams", name: "Records_RecordID", newName: "RecordID");
            RenameIndex(table: "dbo.Teams", name: "IX_Records_RecordID", newName: "IX_RecordID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Teams", name: "IX_RecordID", newName: "IX_Records_RecordID");
            RenameColumn(table: "dbo.Teams", name: "RecordID", newName: "Records_RecordID");
        }
    }
}

namespace BocceBallLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAllRecordofRecords : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "Records_RecordID", "dbo.Records");
            DropIndex("dbo.Teams", new[] { "Records_RecordID" });
            DropColumn("dbo.Teams", "Records_RecordID");
            DropTable("dbo.Records");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID);
            
            AddColumn("dbo.Teams", "Records_RecordID", c => c.Int());
            CreateIndex("dbo.Teams", "Records_RecordID");
            AddForeignKey("dbo.Teams", "Records_RecordID", "dbo.Records", "RecordID");
        }
    }
}

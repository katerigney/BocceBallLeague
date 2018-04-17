namespace BocceBallLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HomeTeamID = c.Int(),
                        AwayTeamID = c.Int(),
                        HomeScore = c.Int(nullable: false),
                        AwayScore = c.String(),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.AwayTeamID)
                .ForeignKey("dbo.Teams", t => t.HomeTeamID)
                .Index(t => t.HomeTeamID)
                .Index(t => t.AwayTeamID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mascot = c.String(),
                        Colors = c.String(),
                        Records_RecordID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Records", t => t.Records_RecordID)
                .Index(t => t.Records_RecordID);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Nickname = c.String(),
                        Number = c.Int(nullable: false),
                        ThrowingArm = c.String(),
                        TeamID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.TeamID)
                .Index(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.Games", "HomeTeamID", "dbo.Teams");
            DropForeignKey("dbo.Games", "AwayTeamID", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Records_RecordID", "dbo.Records");
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropIndex("dbo.Teams", new[] { "Records_RecordID" });
            DropIndex("dbo.Games", new[] { "AwayTeamID" });
            DropIndex("dbo.Games", new[] { "HomeTeamID" });
            DropTable("dbo.Players");
            DropTable("dbo.Records");
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
        }
    }
}

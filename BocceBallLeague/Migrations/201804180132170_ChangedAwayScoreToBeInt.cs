namespace BocceBallLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAwayScoreToBeInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "AwayScore", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "AwayScore", c => c.String());
        }
    }
}

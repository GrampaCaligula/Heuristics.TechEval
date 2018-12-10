namespace Heuristics.TechEval.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dgaddie : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Member", "CategoryId", "dbo.Category", "Id");
        }
        
        public override void Down()
        {

        }
    }
}

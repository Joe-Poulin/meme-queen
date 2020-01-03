namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clean : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memes", "MemeAmount", c => c.Int());
        }

        public override void Down()
        {
        }
    }
}

namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedSeenMemesFromUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Memes", "User_Id", "dbo.Users");
            DropIndex("dbo.Memes", new[] { "User_Id" });
            DropColumn("dbo.Memes", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Memes", "User_Id", c => c.Int());
            CreateIndex("dbo.Memes", "User_Id");
            AddForeignKey("dbo.Memes", "User_Id", "dbo.Users", "Id");
        }
    }
}

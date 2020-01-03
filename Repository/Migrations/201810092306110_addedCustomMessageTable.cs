namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCustomMessageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        Date = c.DateTime(nullable: false),
                        CustomMessageType = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);

            AddColumn("dbo.Users", "MemeAmount", c => c.Int());
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "MemeAmount", c => c.Int(nullable: false));
            DropForeignKey("dbo.CustomMessages", "User_Id", "dbo.Users");
            DropIndex("dbo.CustomMessages", new[] { "User_Id" });
            DropTable("dbo.CustomMessages");
        }
    }
}

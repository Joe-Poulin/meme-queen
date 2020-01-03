namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMemetimeToUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        UsePhoneNumber = c.Boolean(nullable: false),
                        UseEmailAddress = c.Boolean(nullable: false),
                        MemeTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Memes", "User_Id", "dbo.Users");
            DropIndex("dbo.Memes", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Memes");
        }
    }
}

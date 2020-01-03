namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedCustomMessageFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomMessages", "User_Id", "dbo.Users");
            DropIndex("dbo.CustomMessages", new[] { "User_Id" });
            RenameColumn(table: "dbo.CustomMessages", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.CustomMessages", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomMessages", "UserId");
            AddForeignKey("dbo.CustomMessages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomMessages", "UserId", "dbo.Users");
            DropIndex("dbo.CustomMessages", new[] { "UserId" });
            AlterColumn("dbo.CustomMessages", "UserId", c => c.Int());
            RenameColumn(table: "dbo.CustomMessages", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.CustomMessages", "User_Id");
            AddForeignKey("dbo.CustomMessages", "User_Id", "dbo.Users", "Id");
        }
    }
}

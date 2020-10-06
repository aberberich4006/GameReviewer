namespace GameReview.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGameReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGameReview", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.UserGameReview", new[] { "UserId" });
            RenameColumn(table: "dbo.UserGameReview", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.UserGameReview", "Review", c => c.String());
            AddColumn("dbo.UserGameReview", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.UserGameReview", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.UserGameReview", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserGameReview", "ApplicationUser_Id");
            AddForeignKey("dbo.UserGameReview", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGameReview", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.UserGameReview", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.UserGameReview", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserGameReview", "CreatedUtc");
            DropColumn("dbo.UserGameReview", "OwnerId");
            DropColumn("dbo.UserGameReview", "Review");
            RenameColumn(table: "dbo.UserGameReview", name: "ApplicationUser_Id", newName: "UserId");
            CreateIndex("dbo.UserGameReview", "UserId");
            AddForeignKey("dbo.UserGameReview", "UserId", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
    }
}

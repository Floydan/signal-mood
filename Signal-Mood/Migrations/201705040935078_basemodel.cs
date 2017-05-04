namespace Signal_Mood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MoodEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        TimeOfRating = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MoodEvents");
        }
    }
}

namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addaciklama : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryAciklama", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryAciklama");
        }
    }
}

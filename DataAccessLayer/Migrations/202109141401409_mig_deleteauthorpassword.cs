namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_deleteauthorpassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Password", c => c.String(maxLength: 50));
        }
    }
}

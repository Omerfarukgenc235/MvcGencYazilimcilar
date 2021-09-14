namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Addhashing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AddColumn("dbo.Authors", "WriterPasswordHash", c => c.Binary());
            AddColumn("dbo.Authors", "WriterPasswordSalt", c => c.Binary());
            DropColumn("dbo.Admins", "UserName");
            DropColumn("dbo.Admins", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Password", c => c.String(maxLength: 20));
            AddColumn("dbo.Admins", "UserName", c => c.String(maxLength: 20));
            DropColumn("dbo.Authors", "WriterPasswordSalt");
            DropColumn("dbo.Authors", "WriterPasswordHash");
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminPasswordHash");
            DropColumn("dbo.Admins", "AdminUserName");
        }
    }
}

namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_roleclassadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yetkis",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Role = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Admins", "AdminYetkiID", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "Yetkis_RoleID", c => c.Int());
            CreateIndex("dbo.Admins", "Yetkis_RoleID");
            AddForeignKey("dbo.Admins", "Yetkis_RoleID", "dbo.Yetkis", "RoleID");
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropForeignKey("dbo.Admins", "Yetkis_RoleID", "dbo.Yetkis");
            DropIndex("dbo.Admins", new[] { "Yetkis_RoleID" });
            DropColumn("dbo.Admins", "Yetkis_RoleID");
            DropColumn("dbo.Admins", "AdminYetkiID");
            DropTable("dbo.Yetkis");
        }
    }
}

namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addabone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubscribeMails",
                c => new
                    {
                        MailID = c.Int(nullable: false, identity: true),
                        Mail = c.String(maxLength: 100),
                        MailDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MailID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubscribeMails");
        }
    }
}

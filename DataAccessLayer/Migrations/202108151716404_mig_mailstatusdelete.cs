namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_mailstatusdelete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SubscribeMails", "MailDurum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubscribeMails", "MailDurum", c => c.Boolean(nullable: false));
        }
    }
}

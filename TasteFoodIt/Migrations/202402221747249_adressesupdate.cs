namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adressesupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adresses", "Phone", c => c.String());
            AlterColumn("dbo.Adresses", "Email", c => c.String());
            AlterColumn("dbo.Adresses", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adresses", "Description", c => c.Int(nullable: false));
            AlterColumn("dbo.Adresses", "Email", c => c.Int(nullable: false));
            AlterColumn("dbo.Adresses", "Phone", c => c.Int(nullable: false));
        }
    }
}

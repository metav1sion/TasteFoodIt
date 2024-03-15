namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "NameSurname", c => c.String());
            AddColumn("dbo.Admins", "ImgURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "ImgURL");
            DropColumn("dbo.Admins", "NameSurname");
        }
    }
}

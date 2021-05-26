namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entreprises", "Adresse_Region", c => c.String());
            DropColumn("dbo.Entreprises", "Adresse_Rue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entreprises", "Adresse_Rue", c => c.String());
            DropColumn("dbo.Entreprises", "Adresse_Region");
        }
    }
}

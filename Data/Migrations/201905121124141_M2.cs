namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entreprises", "Adresse_IdAdresse", "dbo.Adresses");
            DropIndex("dbo.Entreprises", new[] { "Adresse_IdAdresse" });
            AddColumn("dbo.Entreprises", "Adresse_CodePostale", c => c.Int(nullable: false));
            AddColumn("dbo.Entreprises", "Adresse_Rue", c => c.String());
            AddColumn("dbo.Entreprises", "Adresse_Ville", c => c.String());
            DropColumn("dbo.Entreprises", "Adresse_IdAdresse");
            DropTable("dbo.Adresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        IdAdresse = c.Int(nullable: false, identity: true),
                        CodePostale = c.Int(nullable: false),
                        Rue = c.String(),
                        Ville = c.String(),
                    })
                .PrimaryKey(t => t.IdAdresse);
            
            AddColumn("dbo.Entreprises", "Adresse_IdAdresse", c => c.Int());
            DropColumn("dbo.Entreprises", "Adresse_Ville");
            DropColumn("dbo.Entreprises", "Adresse_Rue");
            DropColumn("dbo.Entreprises", "Adresse_CodePostale");
            CreateIndex("dbo.Entreprises", "Adresse_IdAdresse");
            AddForeignKey("dbo.Entreprises", "Adresse_IdAdresse", "dbo.Adresses", "IdAdresse");
        }
    }
}

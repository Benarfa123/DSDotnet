namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entreprises",
                c => new
                    {
                        IdEntreprise = c.Int(nullable: false, identity: true),
                        NomEntreprise = c.String(maxLength: 50),
                        Description = c.String(),
                        DateFondation = c.DateTime(nullable: false),
                        Effectif = c.Int(nullable: false),
                        ChiffreAffaire = c.Int(nullable: false),
                        Secteur = c.Int(nullable: false),
                        Adresse_IdAdresse = c.Int(),
                    })
                .PrimaryKey(t => t.IdEntreprise)
                .ForeignKey("dbo.Adresses", t => t.Adresse_IdAdresse)
                .Index(t => t.Adresse_IdAdresse);
            
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
            
            CreateTable(
                "dbo.Offres",
                c => new
                    {
                        IdOffre = c.Int(nullable: false, identity: true),
                        TitreOffre = c.String(),
                        Description = c.String(),
                        DatePublication = c.DateTime(nullable: false),
                        TypeContrat = c.Int(nullable: false),
                        Entreprise_IdEntreprise = c.Int(),
                    })
                .PrimaryKey(t => t.IdOffre)
                .ForeignKey("dbo.Entreprises", t => t.Entreprise_IdEntreprise)
                .Index(t => t.Entreprise_IdEntreprise);
            
            CreateTable(
                "dbo.Postulants",
                c => new
                    {
                        IdPostulant = c.Int(nullable: false, identity: true),
                        Prenom = c.String(maxLength: 50),
                        Nom = c.String(maxLength: 50),
                        DateNaissance = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdPostulant);
            
            CreateTable(
                "dbo.Candidature",
                c => new
                    {
                        Postulant_IdPostulant = c.Int(nullable: false),
                        Offre_IdOffre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Postulant_IdPostulant, t.Offre_IdOffre })
                .ForeignKey("dbo.Postulants", t => t.Postulant_IdPostulant, cascadeDelete: true)
                .ForeignKey("dbo.Offres", t => t.Offre_IdOffre, cascadeDelete: true)
                .Index(t => t.Postulant_IdPostulant)
                .Index(t => t.Offre_IdOffre);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidature", "Offre_IdOffre", "dbo.Offres");
            DropForeignKey("dbo.Candidature", "Postulant_IdPostulant", "dbo.Postulants");
            DropForeignKey("dbo.Offres", "Entreprise_IdEntreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Entreprises", "Adresse_IdAdresse", "dbo.Adresses");
            DropIndex("dbo.Candidature", new[] { "Offre_IdOffre" });
            DropIndex("dbo.Candidature", new[] { "Postulant_IdPostulant" });
            DropIndex("dbo.Offres", new[] { "Entreprise_IdEntreprise" });
            DropIndex("dbo.Entreprises", new[] { "Adresse_IdAdresse" });
            DropTable("dbo.Candidature");
            DropTable("dbo.Postulants");
            DropTable("dbo.Offres");
            DropTable("dbo.Adresses");
            DropTable("dbo.Entreprises");
        }
    }
}

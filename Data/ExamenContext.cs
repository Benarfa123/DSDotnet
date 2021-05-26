using Data.MyConfigurations;
using Data.MyConventions;
using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
  public  class ExamenContext : DbContext
    {
        public ExamenContext() : base("name=Alias")
        {

        }
        public DbSet<Postulant> Postulants { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Convention
            modelBuilder.Conventions.Add(new KeyConvention());
            
            //    //Fluent API
            modelBuilder.Configurations.Add(new CandidatureConfiguration());
           

        }
    }
}
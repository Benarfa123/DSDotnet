using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MyConfigurations
{
    public class CandidatureConfiguration : EntityTypeConfiguration<Postulant>
    {
        public CandidatureConfiguration()
        {
            HasMany<Offre>(e => e.Offres).WithMany(e => e.Postulants).Map(r => { r.ToTable("Candidature"); });

        }
    }
}

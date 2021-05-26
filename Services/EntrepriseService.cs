using Data.Infrastructure;
using Domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EntrepriseService : Service<Entreprise>, IEntrepriseService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public EntrepriseService() : base(uow)
        {

        }

        //Methode3
        public IEnumerable<Entreprise> Top2Entreprise()
        {
            var linq = (from i in uow.getRepository<Offre>().GetAll()
                    join j in GetAll() on i.Entreprise.IdEntreprise equals j.IdEntreprise
                    where i.TypeContrat == TypeContrat.Stage
                    orderby i.Postulants.Count()
                    select j).Take(2);
            return linq;
        }

        //Methode4
        public int NbrPME()
        {

            return GetAll().Where(p =>( p.Effectif > 10) && (p.Effectif < 250) && (p.ChiffreAffaire < 50000000)).Count();

        }
    }
}

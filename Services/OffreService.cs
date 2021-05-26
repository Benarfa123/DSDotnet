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
    public class OffreService : Service<Offre>, IOffreService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public OffreService() : base(uow)
        {

        }

        //Methode1
        public IEnumerable<Offre> ListeOffresMoisEnCours()
        {
            var v = GetMany(o => (o.DatePublication.Month == DateTime.Now.Month) && (o.DatePublication.Year == DateTime.Now.Year)).OfType<Offre>();
            foreach (var item in v)
            {
                Console.WriteLine("Offre" + item.TitreOffre);
            }
            return v;
        }
    }
}

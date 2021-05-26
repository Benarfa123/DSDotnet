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
    public class PostulantService : Service<Postulant>, IPostulantService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public PostulantService() : base(uow)
        {

        }

        //Methode2
        public int NbrOffres(int id)
        {
            return GetAll().Where(p => p.IdPostulant == id).Select(p => p.Offres).Count();
        }



    }
}

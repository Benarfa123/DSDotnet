﻿using Domaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOffreService : IService<Offre>
    {
        IEnumerable<Offre> ListeOffresMoisEnCours();
    }
}

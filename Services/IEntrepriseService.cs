using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEntrepriseService
    {
        IEnumerable<Entreprise> Top2Entreprise();
        int NbrPME();
    }
}

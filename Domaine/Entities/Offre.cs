using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entities
{
    public enum TypeContrat { CDI, CDD, Stage, Freelance}
    public class Offre
    {
        public int IdOffre { get; set; }
        public String TitreOffre { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DatePublication { get; set; }

        public TypeContrat TypeContrat { get; set; }

        //Navigation
        public virtual ICollection<Postulant> Postulants { get; set; }
        public virtual Entreprise Entreprise { get; set; }
    }
}

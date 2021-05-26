using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entities
{
    public enum Secteur {Informatique, Energie, Immobilier, Automobile, Commerce, Finance, Transport, Tourisme, Publique, Autres }
    public class Entreprise
    {
        public int IdEntreprise { get; set; }

        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        [MaxLength(50)]
        public string NomEntreprise { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateFondation { get; set; }

        [Range(0, double.MaxValue)]
        public int Effectif { get; set; }

        [DataType(DataType.Currency)]
        public int ChiffreAffaire { get; set; }

        public Secteur Secteur { get; set; }
        public Adresse Adresse { get; set; }

        //Navigation
        public virtual ICollection<Offre> Offres { get; set; }
    }
}

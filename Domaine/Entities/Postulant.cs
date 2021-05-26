using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entities
{
    public class Postulant
    {
        
        public int IdPostulant { get; set; }
        
        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        [MaxLength(50)]
        public string Prenom { get; set; }

        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        [MaxLength(50)]
        public string Nom { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateNaissance { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        //Navigation
        public virtual ICollection<Offre> Offres { get; set; }
    }
}

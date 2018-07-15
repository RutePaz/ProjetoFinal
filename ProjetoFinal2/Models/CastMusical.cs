using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI2PFINAL.Models
{
    public class CastMusical
    {

        ///* public int ID { get; set; } // PK*/, por exigência da Entity Framework

        //chave primária
        [Key]
        public int ID { get; set; }

        //Foreign Keys 
        [ForeignKey("Musical")]
        public int MusicalFK { get; set; }
        public virtual Musical Musical { get; set; }

        [ForeignKey("Cast")]
        public int CastFK { get; set; }
        public virtual Cast Cast { get; set; }

        //atributos
        [Required(ErrorMessage = " {0} required field!")]
        //[RegularExpression("[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûäëïöüãõç]+(( |'|-| dos | da | de | e | d')[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûäëïöüãõç]+){0,3}",
        //ErrorMessage = "O {0} it can only contain letters of blank spaces. Each word has to begin with a capital letter followed by a lower case letters...")]
        public string Character { get; set; }

        public string Image { get; set; }

    }
}
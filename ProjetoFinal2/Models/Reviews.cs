using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI2PFINAL.Models
{
    public class Reviews
    {
        [Key]
        public int ID_Review { get; set; }
        public string Review { get; set; }

        //atributo, da tabela Musical, que será referênciado na tabela Reviews
        [ForeignKey("Musical")]
        public int MusicalFK { get; set; }
        //chama, neste caso, o musical da tabela Musical
        public virtual Musical Musical { get; set; }

        [ForeignKey("User")]
        public int UserFK { get; set; }
        //chama, neste caso, o musical da tabela Musical
        public virtual User User { get; set; }

    }
}
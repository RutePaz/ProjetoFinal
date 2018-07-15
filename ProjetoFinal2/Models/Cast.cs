using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TI2PFINAL.Models
{
    public class Cast
    {
        public Cast()
        {
            ListMusical = new HashSet<CastMusical>();

        }

        [Key]
        public int ID_Actor { get; set; }
        [Required(ErrorMessage = " {0} required field!")]
        public string Name { get; set; }
        public string Image { get; set; }



        public virtual ICollection<CastMusical> ListMusical { get; set; }



        //atributo, da tabela Musical, que será referênciado na tabela Cast
        //[ForeignKey("Musical")]
        //public int MusicalFK { get; set; }
        //chama, neste caso, o musical da tabela Musical
        //public virtual Musical Musical { get; set; }

    }
}
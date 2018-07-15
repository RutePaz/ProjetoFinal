using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TI2PFINAL.Models
{
    public class User
    {
        public User()
        {
            ListReviews = new HashSet<Reviews>();
        }
        [Key]
        public int ID_User { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // referência ás reviews que um musical apresenta
        public virtual ICollection<Reviews> ListReviews { get; set; }

    }
}
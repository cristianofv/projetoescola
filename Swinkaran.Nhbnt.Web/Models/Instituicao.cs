using Ensino.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ensino.Web.Models
{
    public class Instituicao
    {
        [Required]
        public virtual long ID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public virtual string Nome { get; set; }
    }
}
using Ensino.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ensino.Web.Models
{
    public class Professor
    {
        [Required]
        public virtual long ID { get; set; }

        [Required]
        [Display(Name = "Nome do Professor")]
        [StringLength(50)]
        public virtual string Nome { get; set; }

        [Required]
        [Display(Name = "Ativo")]
        public virtual bool Ativo { get; set; }

        [Required]
        [Display(Name = "Instituição")]
        public virtual int? InstituicaoID { get; set; }

        public virtual Instituicao Instituicao { get; set; }

        public virtual IQueryable<Turma> Turmas { get; set; }
        public virtual List<Instituicao> ListaInstituicao{ get; set; }

    }
}
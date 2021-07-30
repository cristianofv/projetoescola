using Ensino.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ensino.Web.Models
{
    public class TurmaAluno
    {
        [Required]
        public virtual long ID { get; set; }

        [Required]
        [Display(Name = "Data de Ingresso")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DataIngresso { get; set; }

        [Required]
        [Display(Name = "Ativo")]
        public virtual bool Ativo { get; set; }

        [Required]
        [Display(Name = "Turma")]
        public virtual int? TurmaID { get; set; }

        public virtual Turma Turma { get; set; }


        [Required]
        [Display(Name = "Aluno")]
        public virtual int? AlunoID { get; set; }

        public virtual Aluno Aluno { get; set; }

    }
}
using Ensino.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ensino.Web.Models
{
    public class Aluno
    {

        [Required]

        public virtual int ID { get; set; }

        [Required]
        [Display(Name = "Nome do Aluno")]
        [StringLength(50)]
        public virtual string Nome { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DataNascimento { get; set; }

        [Required]
        [Display(Name = "Genero")]
        [StringLength(1)]
        public virtual string Genero { get; set; }

        public virtual ICollection<TurmaAluno> ListaTurmaAluno { get; set; } = new List<TurmaAluno>();
    }
}
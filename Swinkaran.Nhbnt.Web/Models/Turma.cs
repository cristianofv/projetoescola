using Ensino.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ensino.Web.Models
{
    public class Turma
    {
       
        [Required]
        public virtual long ID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public virtual string Nome { get; set; }

        [Required]
        [Display(Name = "Ativo")]
        public virtual bool Ativo { get; set; }

        [Required]
        [Display(Name = "Ano")]
        public virtual int Ano { get; set; }

        [Required]
        [Display(Name = "Disciplina")]
        public virtual int? DisciplinaID { get; set; }

        public virtual Disciplina Disciplina { get; set; }

        [Required]
        [Display(Name = "Professor")]
        public virtual int? ProfessorID { get; set; }

        public virtual Professor Professor { get; set; }

        public virtual ICollection<TurmaAluno> ListaTurmaAluno { get; set; } = new List<TurmaAluno>();

    }
}
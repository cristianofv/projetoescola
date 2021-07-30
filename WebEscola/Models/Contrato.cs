using Ensino.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ensino.Web.Models
{
    public class Contrato
    {
        [Required]
        public virtual long ID { get; set; }

        [Display(Name = "Data do Contrato")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime? Data { get; set; }

        [Required]
        [Display(Name = "Ativo")]
        public virtual bool Ativo { get; set; }


        [Required]
        [Display(Name = "Dia do Vencimento Mensalidade")]
        public virtual int DiaVencimento { get; set; }


        [Required]
        [Display(Name = "Valor da Mensalidade")]
        public virtual double ValorMensalidade { get; set; }

        [Required]
        [Display(Name = "Aluno")]
        public virtual int? AlunoID { get; set; }

        public virtual Aluno Aluno { get; set; }


        [Required]
        [Display(Name = "Instituicao")]
        public virtual int? InstituicaoID { get; set; }

        public virtual Instituicao Instituicao { get; set; }

    }
}
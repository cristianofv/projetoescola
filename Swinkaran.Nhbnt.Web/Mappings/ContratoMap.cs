using Ensino.Web.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensino.Web.Mappings
{
    public class ContratoMap : ClassMap<Contrato>
    {
        public ContratoMap()
        {
            Table("CONTRATO");
            Id(x => x.ID);

            Map(x => x.InstituicaoID).Column("INSTITUICAO_ID");
            References(x => x.Instituicao).Column("INSTITUICAO_ID").Not.Insert().Not.Update().Not.LazyLoad();

            Map(x => x.AlunoID).Column("ALUNO_ID");
            References(x => x.Aluno).Column("ALUNO_ID").Not.Insert().Not.Update().Not.LazyLoad();


            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.DiaVencimento).Column("DIA_VENCIMENTO");
            Map(x => x.ValorMensalidade).Column("VALOR_MENSALIDADE");
            Map(x => x.Data).Column("DATA");
        }
    }
}
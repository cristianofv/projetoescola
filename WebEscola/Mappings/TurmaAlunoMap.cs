using Ensino.Web.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensino.Web.Mappings
{
    public class TurmaAlunoMap : ClassMap<TurmaAluno>
    {
        public TurmaAlunoMap()
        {
            Table("TURMA_ALUNO");
            Id(x => x.ID);
            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.DataIngresso).Column("DATA_INGRESSO");

            Map(x => x.TurmaID).Column("TURMA_ID");
            References(x => x.Turma).Column("TURMA_ID").Not.Insert().Not.Update().Not.LazyLoad();

            Map(x => x.AlunoID).Column("ALUNO_ID");
            References(x => x.Aluno).Column("ALUNO_ID").Not.Insert().Not.Update().Not.LazyLoad();

        }
    }
}
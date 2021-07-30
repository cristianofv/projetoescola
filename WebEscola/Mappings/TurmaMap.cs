using Ensino.Web.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensino.Web.Mappings
{
    public class TurmaMap : ClassMap<Turma>
    {
        public TurmaMap()
        {
            Table("TURMA");
            Id(x => x.ID);
            Map(x => x.Nome).Column("NOME");
            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.Ano).Column("ANO");

            Map(x => x.ProfessorID).Column("PROFESSOR_ID");
            References(x => x.Professor).Column("PROFESSOR_ID").Not.Insert().Not.Update().Not.LazyLoad();

            Map(x => x.DisciplinaID).Column("DISCIPLINA_ID");
            References(x => x.Disciplina).Column("DISCIPLINA_ID").Not.Insert().Not.Update().Not.LazyLoad();

            HasMany(x => x.ListaTurmaAluno).KeyColumns.Add("TURMA_ID").AsBag().Not.LazyLoad();

        }
    }
}
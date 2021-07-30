using Ensino.Web.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensino.Web.Mappings
{
    public class AlunoMap : ClassMap<Aluno>
    {
        public AlunoMap()
        {
            Table("ALUNO");
            Id(x => x.ID);
            Map(x => x.Nome).Column("NOME");
            Map(x => x.DataNascimento).Column("DATA_NASCIMENTO");
            Map(x => x.Genero).Column("GENERO");

            HasMany(x => x.ListaTurmaAluno).KeyColumns.Add("TURMA_ID").AsBag().Not.LazyLoad();
        }
    }
}
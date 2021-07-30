using Ensino.Web.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensino.Web.Mappings
{
    public class DisciplinaMap : ClassMap<Disciplina>
    {
        public DisciplinaMap()
        {
            Table("DISCIPLINA");
            Id(x => x.ID);
            Map(x => x.Nome).Column("NOME");
            Map(x => x.Ativo).Column("ATIVO");
        }
    }
}
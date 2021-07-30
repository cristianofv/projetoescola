using Ensino.Web.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensino.Web.Mappings
{
    public class ProfessorMap : ClassMap<Professor>
    {
        public ProfessorMap()
        {
            Table("PROFESSOR");
            Id(x => x.ID);
            Map(x => x.Nome).Column("NOME");
            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.InstituicaoID).Column("INSTITUICAO_ID");
            References(x => x.Instituicao).Column("INSTITUICAO_ID").Not.Insert().Not.Update().Not.LazyLoad();
        }
    }
}
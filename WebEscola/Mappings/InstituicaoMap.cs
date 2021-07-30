using Ensino.Web.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensino.Web.Mappings
{
    public class InstituicaoMap : ClassMap<Instituicao>
    {
        public InstituicaoMap()
        {
            Table("INSTITUICAO");
            Id(x => x.ID);
            Map(x => x.Nome).Column("NOME");
        }
    }
}
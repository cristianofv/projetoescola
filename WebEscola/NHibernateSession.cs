using Ensino.Web.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensino.Web
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(@"Data Source=DESKTOP-UPLIAGO;Initial Catalog=dbEnsino;Integrated Security=True")
                              .ShowSql()
                )
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Professor>())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Aluno>())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Instituicao>())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TurmaAluno>())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Turma>())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Disciplina>())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Contrato>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
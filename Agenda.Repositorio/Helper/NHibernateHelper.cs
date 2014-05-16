using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Agenda.Repositorio.Helper
{
    class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISession OpenSession()
        {
            return SessionFactory().OpenSession();
        }

        private static ISessionFactory SessionFactory()
        {
            if (_sessionFactory != null)
            {
                return _sessionFactory;
            }

            var config = Fluently.Configure()
                    .Database(MySQLConfiguration.Standard.ConnectionString(
                c => c.Database("agenda").Server("localhost").Username("usuario").Password("senha")

                    )
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateHelper>())
                .ExposeConfiguration(c => c.Properties.Add("hbm2ddl.keywords", "none"))

              // Cria as tabelas do Banco de Dados

              .ExposeConfiguration(cfg =>
                   {
                       new SchemaUpdate(cfg)
                         .Execute(false, true);
                   })
                //.ExposeConfiguration(cfg =>
                //{
                //    new SchemaExport(cfg)
                //    .Create(false, true);
                //})
                .BuildSessionFactory();

            return _sessionFactory = config;
        }
    }
}

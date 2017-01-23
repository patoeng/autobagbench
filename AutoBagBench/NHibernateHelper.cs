using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace AutoBagBench
{
    public class NHibernateHelper{
 
    public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();

        }

        private static ISessionFactory _sessionFactory;
        public static string ConnectionString = SettingHelper.DatabaseConnection();
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    CreateSessionFactory();

                return _sessionFactory;
            }
        }

        private static void CreateSessionFactory()
        {
            try
            {
                NHibernate.Cfg.Configuration ff = new Configuration();
                var cfgs = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProcessData>())
                    .ExposeConfiguration(cfg => ff = cfg);
                    
                SchemaValidator f = new SchemaValidator(ff);

                _sessionFactory = cfgs.BuildSessionFactory();

            }
            catch (Exception ex1)
            {
                try
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql().Dialect("NHibernate.Dialect.MsSql2008Dialect"))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProcessData>())
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();

                }
                catch (Exception ex2)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql().Dialect("NHibernate.Dialect.MsSql2008Dialect"))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProcessData>())
                        .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
                        .BuildSessionFactory();
                }
            }
        }
    }
}
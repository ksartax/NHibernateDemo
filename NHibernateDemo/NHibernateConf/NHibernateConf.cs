using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace NHibernateDemo
{
    public static class NHibernateConf
    {
        public static ISessionFactory GetSession()
        {
            NHibernateProfiler.Initialize();

            var cfg = new Configuration();

            cfg.Configure("NHibernateConf/hibernate.cfg.xml");
            cfg.DataBaseIntegration(x =>
            {
                //x.ConnectionStringName = "default";
                //x.Driver<SqlClientDriver>();
                //x.Dialect<MsSql2008Dialect>();
                x.Timeout = 10;
               // x.LogSqlInConsole = true;
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            return cfg.BuildSessionFactory();
        }
    }
}

using System.Linq;
using BenchmarkDotNet.Attributes;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Driver;

namespace OrmBenchmark
{
    public partial class Benchmark
    {
        private static readonly ISessionFactory DefaultSessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
                .Driver<MicrosoftDataSqlClientDriver>()
                .ConnectionString(Constants.CONNECTION_STRING))
            .Mappings(x => { x.FluentMappings.AddFromAssembly(typeof(SimpleEntity).Assembly); })
            .BuildConfiguration()
            .BuildSessionFactory();

        [Benchmark]
        public int NHibernateStateless_Default()
        {
            using var session = DefaultSessionFactory.OpenStatelessSession();
            {
                var result = session.Query<SimpleEntity>().ToList();
                return result.Count;
            }
        }

        [Benchmark]
        public int NHibernateStateful_Default()
        {
            using var session = DefaultSessionFactory.OpenSession();

            var result = session.Query<SimpleEntity>().ToList();
            return result.Count;
        }
    }
}
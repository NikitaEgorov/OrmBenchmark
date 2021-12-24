using System.Linq;
using BenchmarkDotNet.Attributes;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Driver;

namespace OrmBenchmark
{
    public partial class Benchmark
    {
        private static readonly ISessionFactory OptimizedSessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
                .Driver<MicrosoftDataSqlClientDriver>()
                .ConnectionString(Constants.CONNECTION_STRING))
            .Mappings(x => { x.FluentMappings.AddFromAssembly(typeof(SimpleEntity).Assembly); })
            .ExposeConfiguration(config =>
            {
                config
                    .SetProperty(Environment.FormatSql, bool.FalseString)
                    .SetProperty(Environment.GenerateStatistics, bool.FalseString)
                    .SetProperty(Environment.Hbm2ddlKeyWords, Hbm2DDLKeyWords.None.ToString())
                    .SetProperty(Environment.PrepareSql, bool.TrueString)
                    .SetProperty(Environment.PropertyUseReflectionOptimizer, bool.TrueString)
                    .SetProperty(Environment.QueryStartupChecking, bool.FalseString)
                    .SetProperty(Environment.ShowSql, bool.FalseString)
                    .SetProperty(Environment.UseProxyValidator, bool.FalseString)
                    .SetProperty(Environment.UseSecondLevelCache, bool.FalseString)
                    .SetProperty(Environment.UseSqlComments, bool.FalseString)
                    .SetProperty(Environment.UseQueryCache, bool.FalseString)
                    .SetProperty(Environment.WrapResultSets, bool.TrueString)
                    .SetProperty(Environment.TrackSessionId, bool.FalseString);
            })
            .BuildConfiguration()
            .BuildSessionFactory();

        [Benchmark]
        public int NHibernateStateless_Optimized()
        {
            using var session = OptimizedSessionFactory.OpenStatelessSession();
            {
                var result = session.Query<SimpleEntity>().ToList();
                return result.Count;
            }
        }

        [Benchmark]
        public int NHibernateStateful_Optimized()
        {
            using var session = OptimizedSessionFactory.OpenSession();

            var result = session.Query<SimpleEntity>().ToList();
            return result.Count;
        }
    }
}
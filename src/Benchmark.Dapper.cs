using System.Linq;
using BenchmarkDotNet.Attributes;
using Dapper;
using Microsoft.Data.SqlClient;

namespace OrmBenchmark
{
    public partial class Benchmark
    {
        [Benchmark(Baseline = true)]
        public int Dapper()
        {
            using var connection = new SqlConnection(Constants.CONNECTION_STRING);
            connection.Open();

            var result = connection.Query<SimpleEntity>("SELECT * FROM ORM_BENCHMARK_TABLE").ToList();
            return result.Count;
        }
    }
}
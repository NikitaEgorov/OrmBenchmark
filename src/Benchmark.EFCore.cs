using System.Linq;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using OrmBenchmark.EFCore;

namespace OrmBenchmark
{
    public partial class Benchmark
    {
        [Benchmark]
        public int EFCoreWithTracking()
        {
            using var db = new EFCoreContext();

            var result = db.SimpleTables.AsTracking().ToList();
            return result.Count;
        }

        [Benchmark]
        public int EFCoreWithNoTracking()
        {
            using var db = new EFCoreContext();

            var result = db.SimpleTables.AsNoTracking().ToList();
            return result.Count;
        }
    }
}

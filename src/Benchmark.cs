using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace OrmBenchmark
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.ColdStart, launchCount: 1, targetCount: 5)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public partial class Benchmark
    {
    }
}

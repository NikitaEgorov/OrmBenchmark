using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace OrmBenchmark
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var config = new ManualConfig()
                .WithOption(ConfigOptions.DisableOptimizationsValidator, true)
                .AddValidator(JitOptimizationsValidator.DontFailOnError)
                .AddLogger(ConsoleLogger.Default)
                .AddColumnProvider(DefaultColumnProviders.Instance);

            BenchmarkRunner.Run(typeof(Program).Assembly, config);
        }
    }
}

using System;
using System.Threading.Tasks;
using CpuDotnetBenchmark.Shared;

namespace CpuDotnetBenchmark.NetCore
{
    class Program
    {
        private static int _threadCount;
        private static int _numberCount;

        public static async Task Main(string[] args)
        {
            _threadCount = args.Length > 0 ? int.Parse(args[0]) : 1;
            _numberCount = args.Length > 1 ? int.Parse(args[1]) : 10000;
            Console.WriteLine($"Calculating {_numberCount} numbers in {_threadCount} theads [.NET Core 2.0]");
            await DoCalculations();
        }

        private static async Task DoCalculations()
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    long elapsed = Benchmarks.FillList(_numberCount, _threadCount);
                    Console.WriteLine($"Calculated {_numberCount} numbers in {elapsed} ms");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

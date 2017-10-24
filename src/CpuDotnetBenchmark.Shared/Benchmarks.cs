using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

namespace CpuDotnetBenchmark.Shared
{
    public static class Benchmarks
    {
        private static int GetValue(int inputValue)
        {
            if (inputValue <= 1)
                return 0;
            // kind of complex fucntion
            var rnd = new Random(inputValue);
            const int BUF_LENGTH = 1024;
            var buf = new byte[BUF_LENGTH];
            rnd.NextBytes(buf);
            double intermediate = 0;
            unchecked
            {
                for (int i = 0; i < BUF_LENGTH; i += 8)
                {
                    intermediate += BitConverter.ToDouble(buf, i);
                    intermediate = Math.Abs(intermediate);
                    while (intermediate > 400000000)
                    {
                        intermediate /= 2.1234523498734297432d;
                        if (double.IsNaN(intermediate) || double.IsInfinity(intermediate))
                        {
                            intermediate = 1.1234523498734297432d;
                            break;
                        }
                    }
                }
                while (intermediate > 0 && intermediate < 20000)
                {
                    intermediate *= 9.1235322224445687578d;
                }
                if (intermediate > 1000000000)
                {
                    intermediate = inputValue * 0.123456d;
                }
                intermediate = Math.Abs(intermediate);
                intermediate = Math.Pow(intermediate, Math.PI / 4);
                intermediate = Math.Log(intermediate, 7);
                intermediate *= Math.Pow(inputValue, 5);

                intermediate *= rnd.NextDouble();
                intermediate *= rnd.NextDouble();
                intermediate *= (double)rnd.Next();
                intermediate += rnd.NextDouble() * 900 * rnd.NextDouble() * 1812665.23387d * rnd.Next();
                if (double.IsNaN(intermediate) || double.IsInfinity(intermediate))
                {
                    intermediate = 1.1234523498734297432d;
                }
                intermediate -=
                    (int)BigInteger.Log(
                        BigInteger.Parse("12345678987653354355435455554") * new BigInteger(intermediate),
                        2.694135185d);
                var value = (int)intermediate * 100;
                return value + GetValue((int)(inputValue * 0.9));
            }
        }

        public static long FillList(int count, int degreeOfParallelism)
        {
            var list = new List<int>(count);
            var sw = new Stopwatch();
            if (degreeOfParallelism > 0)
            {
                var opts = new ParallelOptions { MaxDegreeOfParallelism = degreeOfParallelism };
                sw.Start();
                Parallel.For(0, count, opts, (i) => list.Add(GetValue(i)));
            }
            else
            {
                // degreeOfParallelism = 0 => simple "for"
                sw.Start();
                for (int i = 0; i < count; i++)
                {
                    list.Add(GetValue(i));
                }
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}

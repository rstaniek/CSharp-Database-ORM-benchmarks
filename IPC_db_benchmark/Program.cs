using BenchmarkDotNet.Running;
using IPC.Raymond.Benchmark.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkSelect>();
            Console.ReadLine();
        }
    }
}

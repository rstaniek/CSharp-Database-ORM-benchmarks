using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark
{
    [SimpleJob(runStrategy:RunStrategy.Throughput, launchCount: 1, warmupCount: 5, targetCount:10)]
    [MinColumn, MaxColumn, MemoryDiagnoser]
    [HtmlExporter, RPlotExporter, CsvExporter, CsvMeasurementsExporter]
    public class BenchmarkLibTest
    {
        private const int N = 10000;
        private readonly byte[] data;

        private readonly SHA256 sha256 = SHA256.Create();
        private readonly MD5 md5 = MD5.Create();

        public BenchmarkLibTest()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }
}

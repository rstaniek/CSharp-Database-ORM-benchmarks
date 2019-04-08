``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.404 (1809/October2018Update/Redstone5)
AMD Ryzen Threadripper 1920X, 1 CPU, 24 logical and 12 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-XFKEYD : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0

IterationCount=200  LaunchCount=3  RunStrategy=Throughput  
WarmupCount=5  

```
|         Method |       Mean |    Error |    StdDev |     Median |        Min |        Max | Skewness | Rank |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------- |-----------:|---------:|----------:|-----------:|-----------:|-----------:|---------:|-----:|--------:|--------:|--------:|----------:|
|      Insert_EF | 1,389.5 us | 13.29 us |  97.53 us | 1,389.4 us | 1,136.5 us | 1,629.5 us |  -0.0129 |   II |       - |       - |       - | 344.05 KB |
|  Insert_Dapper |   870.2 us | 26.49 us | 186.24 us |   825.4 us |   659.5 us | 1,580.4 us |   1.1258 |    I |  1.9531 |       - |       - |   3.13 KB |
|      Insert_SP | 2,407.9 us | 25.24 us | 183.95 us | 2,397.6 us | 2,127.7 us | 2,990.6 us |   0.3020 |   IV | 78.1250 | 78.1250 | 78.1250 | 273.84 KB |
| Insert_ADO_NET | 2,265.9 us | 25.59 us | 181.08 us | 2,210.7 us | 2,050.1 us | 3,044.2 us |   1.4801 |  III | 78.1250 | 78.1250 | 78.1250 | 273.94 KB |

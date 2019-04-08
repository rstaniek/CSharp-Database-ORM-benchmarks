``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.404 (1809/October2018Update/Redstone5)
AMD Ryzen Threadripper 1920X, 1 CPU, 24 logical and 12 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-XFKEYD : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0

IterationCount=200  LaunchCount=3  RunStrategy=Throughput  
WarmupCount=5  

```
|         Method |     Mean |     Error |    StdDev |   Median |      Min |      Max | Skewness | Rank |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |---------:|----------:|----------:|---------:|---------:|---------:|---------:|-----:|----------:|------:|------:|----------:|
|  Select_EF_Raw | 17.45 ms | 0.0482 ms | 0.3519 ms | 17.39 ms | 16.85 ms | 18.99 ms |   1.3990 |  III | 1000.0000 |     - |     - |   2.42 MB |
| Select_EF_View | 14.49 ms | 0.0301 ms | 0.2202 ms | 14.49 ms | 13.99 ms | 15.09 ms |   0.0324 |    I | 1000.0000 |     - |     - |   1.53 MB |
|  Select_Dapper | 16.78 ms | 0.0260 ms | 0.1907 ms | 16.78 ms | 16.30 ms | 17.28 ms |   0.0603 |   II | 1000.0000 |     - |     - |   1.99 MB |
| Select_ADO_NET | 46.31 ms | 0.0354 ms | 0.2522 ms | 46.29 ms | 45.66 ms | 47.47 ms |   1.1263 |   IV | 1000.0000 |     - |     - |   2.42 MB |
|      Select_SP | 46.48 ms | 0.0748 ms | 0.5384 ms | 46.48 ms | 45.58 ms | 48.60 ms |   1.0375 |   IV | 1000.0000 |     - |     - |   2.42 MB |

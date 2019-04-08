``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.404 (1809/October2018Update/Redstone5)
AMD Ryzen Threadripper 1920X, 1 CPU, 24 logical and 12 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  Job-XFKEYD : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0

IterationCount=200  LaunchCount=3  RunStrategy=Throughput  
WarmupCount=5  

```
|         Method |      Mean |     Error |    StdDev |    Median |       Min |       Max | Skewness | Rank |     Gen 0 | Gen 1 | Gen 2 |   Allocated |
|--------------- |----------:|----------:|----------:|----------:|----------:|----------:|---------:|-----:|----------:|------:|------:|------------:|
|      Insert_EF |  55.59 ms | 0.1635 ms |  1.128 ms |  55.67 ms |  53.30 ms |  59.14 ms |   0.2309 |   II | 3000.0000 |     - |     - |  22206.2 KB |
|  Insert_Dapper |  43.93 ms | 0.4177 ms |  2.977 ms |  42.77 ms |  39.74 ms |  52.90 ms |   0.7512 |    I |         - |     - |     - |      192 KB |
|      Insert_SP | 140.97 ms | 1.4176 ms |  9.956 ms | 137.08 ms | 127.45 ms | 176.54 ms |   1.1971 |  III | 1000.0000 |     - |     - |  17461.5 KB |
| Insert_ADO_NET | 157.11 ms | 1.5320 ms | 11.204 ms | 157.25 ms | 140.40 ms | 188.31 ms |   0.4607 |   IV | 1000.0000 |     - |     - | 17468.27 KB |

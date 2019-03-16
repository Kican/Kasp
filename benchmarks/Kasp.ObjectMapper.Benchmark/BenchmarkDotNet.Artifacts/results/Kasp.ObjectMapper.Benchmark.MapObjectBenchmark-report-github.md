``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.316 (1809/October2018Update/Redstone5)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.104
  [Host] : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT
  Core   : .NET Core 2.2.2 (CoreCLR 4.6.27317.07, CoreFX 4.6.27318.02), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|      Method |       Mean |     Error |    StdDev |        Min |        Max | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------ |-----------:|----------:|----------:|-----------:|-----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|    Baseline |   5.635 ns | 0.0145 ns | 0.0128 ns |   5.614 ns |   5.659 ns |  1.00 |    0.00 |      0.0133 |           - |           - |                56 B |
| BoxedMapper |  11.808 ns | 0.0213 ns | 0.0178 ns |  11.789 ns |  11.853 ns |  2.10 |    0.00 |      0.0133 |           - |           - |                56 B |
|  Automapper | 133.995 ns | 0.1111 ns | 0.0868 ns | 133.808 ns | 134.115 ns | 23.78 |    0.06 |      0.0207 |           - |           - |                88 B |
|     Mapster |  47.201 ns | 0.1211 ns | 0.1074 ns |  46.986 ns |  47.339 ns |  8.38 |    0.03 |      0.0209 |           - |           - |                88 B |

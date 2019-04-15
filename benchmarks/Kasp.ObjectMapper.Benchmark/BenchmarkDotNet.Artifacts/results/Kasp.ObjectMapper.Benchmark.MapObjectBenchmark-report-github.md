``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.437 (1809/October2018Update/Redstone5)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview3-010431
  [Host] : .NET Core 3.0.0-preview3-27503-5 (CoreCLR 4.6.27422.72, CoreFX 4.7.19.12807), 64bit RyuJIT
  Core   : .NET Core 3.0.0-preview3-27503-5 (CoreCLR 4.6.27422.72, CoreFX 4.7.19.12807), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|      Method |       Mean |     Error |    StdDev |     Median |        Min |        Max | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |-----------:|----------:|----------:|-----------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|    Baseline |   7.892 ns | 0.0311 ns | 0.0243 ns |   7.888 ns |   7.855 ns |   7.942 ns |  1.00 |    0.00 | 0.0134 |     - |     - |      56 B |
| BoxedMapper |  13.410 ns | 0.7642 ns | 1.8309 ns |  12.445 ns |  12.373 ns |  17.308 ns |  2.09 |    0.15 | 0.0134 |     - |     - |      56 B |
|  Automapper | 142.079 ns | 1.7838 ns | 1.5813 ns | 142.109 ns | 140.051 ns | 145.950 ns | 18.02 |    0.21 | 0.0210 |     - |     - |      88 B |
|     Mapster |  49.717 ns | 0.5826 ns | 0.5449 ns |  49.470 ns |  49.274 ns |  51.004 ns |  6.29 |    0.08 | 0.0210 |     - |     - |      88 B |

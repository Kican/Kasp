``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview5-011568
  [Host] : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  Core   : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|      Method |       Mean |     Error |    StdDev |        Min |        Max | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |-----------:|----------:|----------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|    Baseline |   5.416 ns | 0.0258 ns | 0.0229 ns |   5.379 ns |   5.465 ns |  1.00 |    0.00 | 0.0133 |     - |     - |      56 B |
| BoxedMapper |  11.922 ns | 0.0236 ns | 0.0197 ns |  11.891 ns |  11.973 ns |  2.20 |    0.01 | 0.0133 |     - |     - |      56 B |
|  Automapper | 131.771 ns | 1.1277 ns | 1.0548 ns | 130.846 ns | 133.858 ns | 24.33 |    0.22 | 0.0207 |     - |     - |      88 B |
|     Mapster |  48.836 ns | 0.2285 ns | 0.2025 ns |  48.657 ns |  49.352 ns |  9.02 |    0.03 | 0.0209 |     - |     - |      88 B |

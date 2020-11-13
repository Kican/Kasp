namespace Kasp.ObjectMapper.Benchmark {
	using BenchmarkDotNet.Running;

	class Program {
		static void Main(string[] args) {
			BenchmarkRunner.Run<MapObjectBenchmark>();
		}
	}
}

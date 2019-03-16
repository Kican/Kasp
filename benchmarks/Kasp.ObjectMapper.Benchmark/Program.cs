using BenchmarkDotNet.Running;

namespace Kasp.ObjectMapper.Benchmark {
	class Program {
		static void Main(string[] args) {
			BenchmarkRunner.Run<MapObjectBenchmark>();
		}
	}
}
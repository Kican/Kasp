using System;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Boxed.Mapping;
using FastExpressionCompiler;
using Kasp.ObjectMapper.Benchmark.Mapping;
using Kasp.ObjectMapper.Benchmark.Models;
using Mapster;

namespace Kasp.ObjectMapper.Benchmark {
	[KeepBenchmarkFiles]
	[CoreJob]
	[MinColumn]
	[MaxColumn]
	[HtmlExporter]
	[CsvMeasurementsExporter]
	[RPlotExporter]
	[MemoryDiagnoser]
	public class MapObjectBenchmark {
		private readonly IMapper automapper;
		private readonly IMapper<MapFrom, MapTo> boilerplateMapper;
		private readonly Random random;
		private MapFrom mapFrom;

		public MapObjectBenchmark() {
			automapper = AutomapperConfiguration.CreateMapper();
			boilerplateMapper = new BoxedMapper();
			random = new Random();
			TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();
		}

		[GlobalSetup]
		public void GlobalSetup() => mapFrom = new MapFrom {
			BooleanFrom = random.NextDouble() > 0.5D,
			DateTimeOffsetFrom = DateTimeOffset.UtcNow,
			IntegerFrom = random.Next(),
			LongFrom = random.Next(),
			StringFrom = random.Next().ToString()
		};

		[Benchmark(Baseline = true)]
		public MapTo Baseline() => new MapTo {
			BooleanTo = mapFrom.BooleanFrom,
			DateTimeOffsetTo = mapFrom.DateTimeOffsetFrom,
			IntegerTo = mapFrom.IntegerFrom,
			LongTo = mapFrom.LongFrom,
			StringTo = mapFrom.StringFrom
		};

		[Benchmark]
		public MapTo BoxedMapper() => boilerplateMapper.Map(mapFrom);

		[Benchmark]
		public MapTo Automapper() => automapper.Map<MapTo>(mapFrom);

		[Benchmark]
		public MapTo Mapster() => mapFrom.Adapt<MapTo>();
	}
}
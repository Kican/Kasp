using System.Reflection;
using Mapster;

namespace Kasp.ObjectMapper.Benchmark.Mapping;

public class MapsterCodeGenerationRegister : ICodeGenerationRegister {
	public void Register(CodeGenerationConfig config) {
		config.AdaptTo("[name]Dto")
			.ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "Kasp.ObjectMapper.Benchmark.Models");

	}
}

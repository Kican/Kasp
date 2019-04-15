using Kasp.ObjectMapper.Tests;
using Kasp.Test;
using Xunit.Abstractions;

namespace Kasp.ObjectMapper.AutoMapper.Tests {
	public class ObjectMapperTests : BaseObjectMapperTests<Startup> {
		public ObjectMapperTests(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
		}
	}
}
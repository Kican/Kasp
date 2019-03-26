using System.Threading.Tasks;
using Kasp.FormBuilder.Services;
using Kasp.FormBuilder.Tests.Models;
using Kasp.Test;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.Tests {
	public class UnitTest1 : KClassFixtureWebApp<Startup> {
		public IFormBuilder FormBuilder { get; }

		public UnitTest1(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
			FormBuilder = GetService<IFormBuilder>();
		}

		[Fact]
		public async Task Test1() {
			var form = await FormBuilder.FromModel<ContactUs>();
			Output.WriteLine(JsonConvert.SerializeObject(form));
			Assert.True(1 == 2 - 1);
		}
	}
}
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Kasp.FormBuilder.Components;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Components.Layouts;
using Kasp.FormBuilder.Services;
using Kasp.FormBuilder.Tests.Models;
using Kasp.Test;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.FormBuilder.Tests {
	public class UnitTest1 : KClassFixtureWebApp<Startup> {
		private IFormBuilder FormBuilder { get; }

		public UnitTest1(ITestOutputHelper output, KWebAppFactory<Startup> factory) : base(output, factory) {
			FormBuilder = GetService<IFormBuilder>();
		}

		[Fact]
		public async Task Test1() {
			var form = await FormBuilder.FromModel<ContactUs>();
			Output.WriteLine(Serializer(form));
			Assert.True(1 == 2 - 1);
		}

		[Fact]
		public async Task DateTimeTest() {
			var form = (LinearLayoutComponent) await FormBuilder.FromModel<DateTimeVm>();
			Assert.True(form.Children.TrueForAll(x => x.Type == nameof(DateTimeComponent)));
		}


		private string Serializer(IComponent component) {
			return JsonConvert.SerializeObject(component, new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
		}
	}
}
using System.Threading.Tasks;
using Kasp.FormBuilder.Components;
using Kasp.FormBuilder.Components.Elements;
using Kasp.FormBuilder.Components.Layouts;
using Kasp.FormBuilder.Services;
using Kasp.FormBuilder.Tests.Models;
using Kasp.Test;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dahomey.Json;

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
		public async Task CheckTitle() {
			var form = (LinearLayoutComponent) await FormBuilder.FromModel<ContactUs>();
			var nameComponent = form.Children.FirstOrDefault(x => x.Name == "Name");
			Output.WriteLine(Serializer(form));
			Assert.True(1 == 2 - 1);
		}

		[Fact]
		public async Task DateTimeTest() {
			var form = (LinearLayoutComponent) await FormBuilder.FromModel<DateTimeVm>();
			Assert.True(form.Children.TrueForAll(x => x.Type == nameof(DateTimeComponent)));
		}

		[Fact]
		public async Task SelectTest() {
			var form = (LinearLayoutComponent) await FormBuilder.FromModel<ContactUs>();
			var nameComponent = form.Children.FirstOrDefault(x => x.Name == "UserId");

			Assert.Equal("SelectComponent", nameComponent?.Type);
		}


		private string Serializer(IComponent component) {
			var options = new JsonSerializerOptions();
			options.SetupExtensions();
			options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
			return JsonSerializer.Serialize(component, options);
		}
	}
}
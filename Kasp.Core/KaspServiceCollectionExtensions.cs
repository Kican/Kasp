using System.Text.Encodings.Web;
using System.Text.Unicode;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Core {
	public static class KaspServiceCollectionExtensions {
		public static KaspServiceBuilder AddKasp(this IServiceCollection services, IConfiguration configuration) {
			services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
			services.AddAutoMapper();

			var kService = new KaspServiceBuilder(services, configuration);

			return kService;
		}
	}


	public class KaspServiceBuilder {
		public KaspServiceBuilder(IServiceCollection services, IConfiguration configuration) {
			Services = services;
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		public IServiceCollection Services { get; }
	}
}
using System.Text.Encodings.Web;
using System.Text.Unicode;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Core.Extensions {
	public static class ServiceCollectionExtensions {
		public static KaspServiceBuilder AddKasp(this IServiceCollection services, IConfiguration configuration, IMvcBuilder mvcBuilder) {
			services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
			services.AddAutoMapper();

			var kService = new KaspServiceBuilder(services, configuration, mvcBuilder);

			return kService;
		}
	}


	public class KaspServiceBuilder {
		public KaspServiceBuilder(IServiceCollection services, IConfiguration configuration, IMvcBuilder mvcBuilder) {
			Services = services;
			Configuration = configuration;
			MvcBuilder = mvcBuilder;
		}

		public IConfiguration Configuration { get; }
		public IServiceCollection Services { get; }
		public IMvcBuilder MvcBuilder { get; }
	}
}
using Kasp.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Localization.Extensions {
	public static class ServiceCollectionExtensions {
		public static KaspServiceBuilder AddLocalization(this KaspServiceBuilder builder) {
			builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

			return builder;
		}
	}

}
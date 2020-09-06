using System;
using Kasp.Panel.Options.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Panel.Options.Extensions {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddKaspPanelOptions(this IServiceCollection services, Action<IOptionsBuilder> optionsAction) {
			var option = new OptionsBuilder();

			optionsAction.Invoke(option);

			services.Configure<PanelOptions>(options => options.Options = option.Options);

			return services;
		}
	}
}
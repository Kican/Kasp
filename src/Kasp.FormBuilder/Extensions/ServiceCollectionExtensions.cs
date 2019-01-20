using Kasp.FormBuilder.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.FormBuilder.Extensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddFormBuilder(this IServiceCollection services) {
            services.AddTransient<IFormBuilder, Services.FormBuilder>();
            return services;
        }
    }
}
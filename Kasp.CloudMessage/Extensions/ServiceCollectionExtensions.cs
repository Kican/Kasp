using Kasp.CloudMessage.Data;
using Kasp.Db.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.CloudMessage.Extensions {
	public static class ServiceCollectionExtensions {
		public static KaspDbServiceBuilder AddCloudMessage(this KaspDbServiceBuilder builder) {
		

			builder.Services.AddScoped(typeof(ICloudMessageRepository), typeof(CloudMessageRepository<>).MakeGenericType(builder.DbContextType));

			return builder;
		}
	}
}
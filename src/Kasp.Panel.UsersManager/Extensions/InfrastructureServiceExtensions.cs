using Kasp.Data.Models.Helpers;
using Kasp.Identity;
using Kasp.Identity.Core.Entities.UserEntities;
using Kasp.Panel.UsersManager.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Panel.UsersManager.Extensions {
	public static class InfrastructureServiceExtensions {
		public static IServiceCollection AddUsersManager<TDbContext, TUser, TRole>(this IServiceCollection services)
			where TUser : KaspUser, IModel
			where TDbContext : KIdentityDbContext<TUser, TRole>
			where TRole : KaspRole {
			services.AddScoped<IUsersManagerService<TUser>, UsersManagerService<TDbContext, TUser, TRole>>();
			return services;
		}
	}
}
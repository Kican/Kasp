using System;
using System.Text;
using Kasp.Db.Extensions;
using Kasp.Identity.Entities;
using Kasp.Identity.Entities.UserEntities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Kasp.Identity.Extensions {
	public static class ServiceCollectionExtensions {
		public static KaspIdentityBuilder AddIdentity<TUser, TRole, TDb>(this KaspDbServiceBuilder builder, Action<IdentityOptions> setupAction = null) where TUser : KaspUser where TRole : KaspRole where TDb : KIdentityDbContext<TUser, TRole> {
			var identityBuilder = new KaspIdentityBuilder(builder) {
				IdentityBuilder = builder.Services.AddIdentity<TUser, TRole>(setupAction).AddEntityFrameworkStores<TDb>().AddDefaultTokenProviders()
			};


			builder.Services.AddScoped(typeof(IUserStore<TUser>), typeof(UserStore<,,,>).MakeGenericType(typeof(TUser), typeof(TRole), typeof(TDb), typeof(int)));
			builder.Services.AddScoped(typeof(IRoleStore<TRole>), typeof(RoleStore<,,>).MakeGenericType(typeof(TRole), typeof(TDb), typeof(int)));

			return identityBuilder;
		}

		public static KaspIdentityBuilder AddAuthorization(this KaspIdentityBuilder identityBuilder, Action<AuthorizationOptions> configure) {
			identityBuilder.Services.AddAuthorization(configure);
			return identityBuilder;
		}


		public static KaspIdentityBuilder AddJwt(this KaspIdentityBuilder builder, IConfiguration config) {
			builder.Services.Configure<JwtConfig>(config);
			return builder;
		}


		public static AuthenticationBuilder AddJwtBearer(this AuthenticationBuilder builder, IConfiguration config) {
			builder.AddJwtBearer(cfg => {
				cfg.RequireHttpsMetadata = false;
				cfg.SaveToken = true;
				cfg.TokenValidationParameters = new TokenValidationParameters() {
					ValidIssuer = config["Issuer"],
					ValidAudience = config["Issuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Key"]))
				};
			});

			return builder;
		}
	}

	public class KaspIdentityBuilder : KaspDbServiceBuilder {
		public IdentityBuilder IdentityBuilder;

		public KaspIdentityBuilder(KaspDbServiceBuilder builder) : base(builder, builder.Configuration) {
		}
	}
}
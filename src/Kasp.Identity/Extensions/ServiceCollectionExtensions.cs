using System.Text;
using Kasp.Identity.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Kasp.Identity.Extensions {
	public static class ServiceCollectionExtensions {
	

		public static IdentityBuilder AddJwt(this IdentityBuilder builder, IConfiguration config) {
			builder.Services.Configure<JwtConfig>(config);
			return builder;
		}


		public static AuthenticationBuilder AddJwtBearer(this AuthenticationBuilder builder, IConfiguration config) {
			builder.AddJwtBearer(cfg => {
				cfg.RequireHttpsMetadata = false;
				cfg.SaveToken = true;
				cfg.TokenValidationParameters = new TokenValidationParameters() {
					ValidIssuer = config["Issuer"], ValidAudience = config["Issuer"], IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Key"]))
				};
			});

			return builder;
		}
	}
}
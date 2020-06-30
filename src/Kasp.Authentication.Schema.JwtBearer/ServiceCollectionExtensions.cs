using System.Text;
using Kasp.Identity.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Kasp.Identity.Schema.JwtBearer {
	public static class ServiceCollectionExtensions {
		public static AuthenticationBuilder AddKaspJwtBearer(this AuthenticationBuilder builder, IConfiguration config) {
			builder.Services.Configure<JwtConfig>(config);

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
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kasp.Identity.Core.Controllers;
using Kasp.Identity.Entities;
using Kasp.Identity.Entities.UserEntities;
using Kasp.Identity.Entities.UserEntities.XEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Kasp.Identity.Controllers {
	public abstract class
		EmailPassAccountApiControllerBase<TUser, TRegisterModel, TViewModel, TEditModel> : AuthApiController
		where TRegisterModel : IUserRegisterModel
		where TUser : KaspUser, new()
		where TViewModel : UserPartialVmBase
		where TEditModel : UserEditModelBase {
		protected EmailPassAccountApiControllerBase(IMapper mapper, IOptions<JwtConfig> config,
			UserManager<TUser> userManager, SignInManager<TUser> signInManager) {
			Mapper = mapper;
			Config = config;
			UserManager = userManager;
			SignInManager = signInManager;
		}

		protected IOptions<JwtConfig> Config { get; }
		protected IMapper Mapper { get; }
		protected UserManager<TUser> UserManager { get; }
		protected SignInManager<TUser> SignInManager { get; }
	

		protected async virtual Task<TokenResponse> GetToken(IEnumerable<Claim> claims) {
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.Value.Key));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

			var token = new JwtSecurityToken(Config.Value.Issuer, Config.Value.Issuer, claims,
				expires: DateTime.UtcNow.AddMinutes(Config.Value.Expire), signingCredentials: credentials);
			var accessToken = new JwtSecurityTokenHandler().WriteToken(token);


			return new TokenResponse() {
				AccessToken = accessToken,
				RefreshToken = GenerateRefreshToken(),
				Expires = token.ValidTo.Ticks
			};
		}

		protected virtual string GenerateRefreshToken() {
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create()) {
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
		}

		protected virtual async Task<List<Claim>> GetClaims(TUser user) {
			var claims = new List<Claim>();

			claims.AddRange(new[] {
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
			});

			var roles = await UserManager.GetRolesAsync(user);

			claims.AddRange(roles.Select(x => new Claim("role", x)));

			return claims;
		}


		protected virtual async Task OnRegisterSuccess(TUser user) {
		}

		[HttpPost, AllowAnonymous]
		public virtual async Task<ActionResult<TViewModel>> Register([FromBody] TRegisterModel model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = Mapper.Map<TUser>(model);

			if (string.IsNullOrEmpty(user.UserName))
				user.UserName = model.Email;

			var result = await UserManager.CreateAsync(user, model.Password);

			if (!result.Succeeded) {
				AddErrors(result);
				return BadRequest(ModelState);
			}

			await OnRegisterSuccess(user);

			return Mapper.Map<TViewModel>(user);
		}
		
		
		[HttpPost, AllowAnonymous]
		public virtual async Task<ActionResult<TokenResponse>> Login([FromBody] LoginVM model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = await UserManager.FindByEmailAsync(model.Email);
			if (user == null) {
				ModelState.AddModelError("", "User not found");
			} else {
				var result = await SignInManager.CheckPasswordSignInAsync(user, model.Password, false);

				if (result.Succeeded) {
					var claims = await GetClaims(user);

					return await GetToken(claims);
				}

				ModelState.AddModelError("", "user/pass incorrect ...");
			}

			return BadRequest(ModelState);
		}




		[HttpPost, AllowAnonymous]
		public virtual async Task<ActionResult<TokenResponse>> Token([FromBody] TokenRequest model) {
			if (model.GrandType == GrandType.Password) {
				var user = await UserManager.FindByNameAsync(model.Username);

				if (user == null) {
					ModelState.AddModelError("", "user-not-found");
				}
				else {
					var result = await SignInManager.CheckPasswordSignInAsync(user, model.Password, false);

					if (result.Succeeded) {
						var claims = await GetClaims(user);

						return await GetToken(claims);
					}

					ModelState.AddModelError("", "user/pass-incorrect");
				}
			}
			else if (model.GrandType == GrandType.RefreshToken) {
			}


			return BadRequest(ModelState);
		}


		[HttpPost]
		public virtual async Task<ActionResult<TViewModel>> Edit([FromBody] TEditModel model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = await UserManager.FindByIdAsync(UserId.ToString());

			user = Mapper.Map(model, user);

			var result = await UserManager.UpdateAsync(user);

			if (!result.Succeeded) {
				AddErrors(result);
				return BadRequest(ModelState);
			}

			return Mapper.Map<TViewModel>(user);
		}

		[HttpGet]
		public virtual async Task<ActionResult<TViewModel>> Info() {
			return await UserManager.Users.ProjectTo<TViewModel>().FirstOrDefaultAsync(x => x.Id == UserId);
		}


		[HttpPost]
		public virtual async Task<IActionResult> ChangePassword([FromBody] ChangePasswordVm model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var user = await UserManager.FindByIdAsync(UserId.ToString());

			var result = await UserManager.ChangePasswordAsync(user, model.Current, model.NewPass);

			if (result.Succeeded)
				return Ok();

			AddErrors(result);
			return BadRequest(ModelState);
		}


		protected void AddErrors(IdentityResult result) {
			foreach (var error in result.Errors) {
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}
	}
}
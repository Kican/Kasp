using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kasp.Identity.Core.Controllers;
using Kasp.Identity.Entities;
using Kasp.Identity.Entities.UserEntities;
using Kasp.Identity.Entities.UserEntities.XEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Kasp.Identity.Controllers {
	public abstract class BaseAccountApiController<TUser, TRegisterModel, TViewModel, TEditModel> : AuthApiController
		where TRegisterModel : IUserRegisterModel
		where TUser : KaspUser
		where TViewModel : UserPartialVmBase
		where TEditModel : UserEditModelBase {
		protected BaseAccountApiController(IMapper mapper, IOptions<JwtConfig> config) {
			Mapper = mapper;
			Config = config;
		}

		protected IOptions<JwtConfig> Config { get; }
		protected IMapper Mapper { get; }

		protected virtual string GetToken(List<Claim> claims) {
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.Value.Key));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

			var token = new JwtSecurityToken(Config.Value.Issuer, Config.Value.Issuer, claims, expires: DateTime.Now.AddMinutes(Config.Value.Expire), signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		protected virtual async Task<List<Claim>> GetClaims(UserManager<TUser> userManager, TUser user) {
			var claims = new List<Claim>();

			claims.AddRange(new[] {
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
			});

			var roles = await userManager.GetRolesAsync(user);

			claims.AddRange(roles.Select(x => new Claim("role", x)));

			return claims;
		}


		protected virtual async Task OnRegisterSuccess(TUser user) {
		}

		[HttpPost]
		public virtual async Task<ActionResult<TViewModel>> Register([FromServices] UserManager<TUser> userManager, [FromBody] TRegisterModel model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = Mapper.Map<TUser>(model);

			if (string.IsNullOrEmpty(user.UserName))
				user.UserName = model.Email;

			var result = await userManager.CreateAsync(user, model.Password);

			if (!result.Succeeded) {
				AddErrors(result);
				return BadRequest(ModelState);
			}

			await OnRegisterSuccess(user);

			return Mapper.Map<TViewModel>(user);
		}


		[HttpPost]
		public virtual async Task<IActionResult> Login([FromServices] UserManager<TUser> userManager, [FromServices] SignInManager<TUser> signInManager, [FromBody] LoginVM model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = await userManager.FindByEmailAsync(model.Email);
			if (user == null) {
				ModelState.AddModelError("", "User not found");
			}
			else {
				var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

				if (result.Succeeded) {
					var claims = await GetClaims(userManager, user);

					return Ok(new {access_token = GetToken(claims)});
				}

				ModelState.AddModelError("", "user/pass incorrect ...");
			}

			return BadRequest(ModelState);
		}


		[HttpPost]
		public virtual async Task<ActionResult<TViewModel>> Edit([FromServices] UserManager<TUser> userManager, [FromBody] TEditModel model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = await userManager.FindByIdAsync(UserId.ToString());

			user = Mapper.Map(model, user);

			var result = await userManager.UpdateAsync(user);

			if (!result.Succeeded) {
				AddErrors(result);
				return BadRequest(ModelState);
			}

			return Mapper.Map<TViewModel>(user);
		}

		[HttpGet]
		public virtual async Task<ActionResult<TViewModel>> Info([FromServices] UserManager<TUser> userManager) {
			return await userManager.Users.ProjectTo<TViewModel>().FirstOrDefaultAsync(x => x.Id == UserId);
		}


		[HttpPost]
		public virtual async Task<IActionResult> ChangePassword([FromServices] UserManager<TUser> userManager, [FromBody] ChangePasswordVm model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var user = await userManager.FindByIdAsync(UserId.ToString());

			var result = await userManager.ChangePasswordAsync(user, model.Current, model.NewPass);

			if (result.Succeeded)
				return Ok();

			AddErrors(result);
			return BadRequest(ModelState);
		}


		private void AddErrors(IdentityResult result) {
			foreach (var error in result.Errors) {
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}
	}
}
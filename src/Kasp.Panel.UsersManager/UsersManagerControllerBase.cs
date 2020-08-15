using System.Threading.Tasks;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Kasp.FormBuilder.Services;
using Kasp.Identity.Core.Entities.UserEntities;
using Kasp.ObjectMapper;
using Kasp.Panel.EntityManager;
using Kasp.Panel.UsersManager.Dtos;
using Kasp.Panel.UsersManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Panel.UsersManager {
	public abstract class
		UsersManagerControllerBase<TUser, TPartialDto> : EntityManagerControllerBase<TUser, IUsersManagerService<TUser>, TPartialDto, TPartialDto, TPartialDto, FilterBase>
		where TPartialDto : class, IModel
		where TUser : KaspUser, IModel {
		protected UsersManagerControllerBase(IUsersManagerService<TUser> repository, IObjectMapper objectMapper, IFormBuilder builder) : base(repository, objectMapper, builder) {
		}

		[HttpGet("$roles")]
		public async Task<ActionResult<RolePartialDto[]>> AllRoles() {
			return await Repository.GetRolesAsync();
		}

		[HttpGet("{id}/$roles")]
		public async Task<ActionResult<RolePartialDto[]>> GetUserRoles(int id) {
			return await Repository.GetUserRolesAsync(id);
		}

		[HttpPut("{id}/$roles")]
		public async Task<IActionResult> SetRoles(int id, [FromBody] SetUserRolesDto model) {
			var result = await Repository.SetUserRolesAsync(id, model.RoleNames);

			if (result.Succeeded)
				return Ok();
			return BadRequest(result.Errors);
		}

		[HttpPut("{id}/$password")]
		public async Task<IActionResult> ChangePassword(int id, [FromBody] SetUserPasswordDto model) {
			var result = await Repository.SetUserPasswordAsync(id, model.Password);

			if (result.Succeeded)
				return Ok();
			return BadRequest(result.Errors);
		}

		[HttpPut("{id}/$email")]
		public async Task<IActionResult> ChangeEmail(int id, [FromBody] SetUserEmailDto model) {
			var result = await Repository.SetUserEmailAsync(id, model.Email);

			if (result.Succeeded)
				return Ok();
			return BadRequest(result.Errors);
		}
	}
}
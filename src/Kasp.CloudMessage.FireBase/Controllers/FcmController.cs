using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Models.FcmDeviceGroupModels;
using Kasp.CloudMessage.FireBase.Models.UserTokenModels.XModels;
using Kasp.CloudMessage.FireBase.Services;
using Kasp.Core.Models;
using Kasp.Identity.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.CloudMessage.FireBase.Controllers {
	public class FcmController : AuthApiController {
		public FcmController(IFcmUserTokenRepository fcmUserTokenRepository, FcmDeviceGroupService deviceGroupService) {
			FcmUserTokenRepository = fcmUserTokenRepository;
			DeviceGroupService = deviceGroupService;
		}

		private IFcmUserTokenRepository FcmUserTokenRepository { get; }
		private FcmDeviceGroupService DeviceGroupService { get; }

		[HttpPost]
		public async Task<IActionResult> AddUserToken([FromBody] FcmUserTokenEditModel model, CancellationToken cancellationToken) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			Result<string> result;

			if (await FcmUserTokenRepository.HasAsync(x => x.UserId == UserId, cancellationToken))
				result = await DeviceGroupService.RequestAsync(DeviceGroupRequestOperation.Add, UserId, model.Token, cancellationToken);
			else
				result = await DeviceGroupService.RequestAsync(DeviceGroupRequestOperation.Create, UserId, model.Token, cancellationToken);

			if (result.IsSuccess) {
				await FcmUserTokenRepository.UpdateUserTokenAsync(UserId, result.Data, cancellationToken);
				return Ok();
			}

			return BadRequest(result.Errors);
		}

		[HttpPost]
		public async Task<IActionResult> RemoveUserToken([FromBody] FcmUserTokenEditModel model, CancellationToken cancellationToken) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await DeviceGroupService.RequestAsync(DeviceGroupRequestOperation.Remove, UserId, model.Token, cancellationToken);
			if (result.IsSuccess) {
				await FcmUserTokenRepository.UpdateUserTokenAsync(UserId, result.Data, cancellationToken);
				return Ok();
			}

			return BadRequest(result.Errors);
		}
	}
}
using System.Threading;
using System.Threading.Tasks;
using Kasp.CloudMessage.FireBase.Data;
using Kasp.CloudMessage.FireBase.Models.UserTokenModels.XModels;
using Kasp.Identity.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.CloudMessage.FireBase.Controllers {
	public class FcmController : AuthApiController {
		public FcmController(IFcmUserTokenRepository fcmUserTokenRepository) {
			FcmUserTokenRepository = fcmUserTokenRepository;
		}

		private IFcmUserTokenRepository FcmUserTokenRepository { get; }

		// todo: use fcm device group
		[HttpPost]
		public async Task<IActionResult> AddUserToken([FromBody] FcmUserTokenEditModel model, CancellationToken cancellationToken) {
			await FcmUserTokenRepository.UpdateUserTokenAsync(UserId, model.Token, cancellationToken);
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> RemoveUserToken([FromBody] FcmUserTokenEditModel model, CancellationToken cancellationToken) {
			await FcmUserTokenRepository.UpdateUserTokenAsync(UserId, model.Token, cancellationToken);
			return Ok();
		}
	}
}
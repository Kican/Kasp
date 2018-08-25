using System.Threading.Tasks;
using Kasp.CloudMessage.Data;
using Kasp.CloudMessage.Models;
using Kasp.CloudMessage.Models.TokenModels;
using Kasp.CloudMessage.Models.TokenModels.XModels;
using Kasp.Identity.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.CloudMessage.Controllers {
	public class CloudMessageController : AuthApiController {
		public CloudMessageController(ICloudMessageRepository messageRepository) {
			MessageRepository = messageRepository;
		}

		private ICloudMessageRepository MessageRepository { get; }

		public async Task<ActionResult<UserCloudMessageToken>> AddToken([FromBody]
			TokenInsertModel model) {
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var tokenModel = new UserCloudMessageToken {Token = model.Token, UserId = UserId};
			await MessageRepository.AddAsync(tokenModel);
			await MessageRepository.SaveAsync();

			return tokenModel;
		}
	}
}
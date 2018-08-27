using System.ComponentModel.DataAnnotations;

namespace Kasp.CloudMessage.FireBase.Models.UserTokenModels.XModels {
	public class FcmUserTokenEditModel {
		[Required, MaxLength(400)]
		public string Token { get; set; }
	}
}
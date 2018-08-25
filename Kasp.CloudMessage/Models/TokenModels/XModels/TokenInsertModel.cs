using System.ComponentModel.DataAnnotations;

namespace Kasp.CloudMessage.Models.TokenModels.XModels {
	public class TokenInsertModel {
		[Required]
		public string Token { get; set; }
	}
}
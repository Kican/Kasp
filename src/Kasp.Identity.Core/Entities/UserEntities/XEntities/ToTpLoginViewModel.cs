using System.ComponentModel.DataAnnotations;

namespace Kasp.Identity.Core.Entities.UserEntities.XEntities {
	public class ToTpLoginViewModel {
		[Required, Phone]
		public string Phone { get; set; }

		[Required]
		public string Code { get; set; }
	}
}
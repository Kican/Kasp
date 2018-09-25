using System.ComponentModel.DataAnnotations;

namespace Kasp.Identity.Entities.UserEntities.XEntities {
	public class ToTpLoginViewModel {
		[Required, Phone]
		public string Phone { get; set; }

		[Required]
		public string Code { get; set; }
	}
}
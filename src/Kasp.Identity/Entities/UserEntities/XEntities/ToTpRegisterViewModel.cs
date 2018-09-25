using System.ComponentModel.DataAnnotations;

namespace Kasp.Identity.Entities.UserEntities.XEntities {
	public class ToTpRegisterViewModel {
		[Required, Phone]
		public string Phone { get; set; }
	}
}
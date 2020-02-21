using System.ComponentModel.DataAnnotations;

namespace Kasp.Identity.Core.Entities.UserEntities.XEntities {
	public class ChangePasswordVm {
		[Required]
		public string Current { get; set; }

		[Required]
		public string NewPass { get; set; }
	}
}
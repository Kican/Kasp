using System.ComponentModel.DataAnnotations;

namespace Kasp.Panel.UsersManager.Dtos {
	public class SetUserEmailDto {

		[Required, EmailAddress]
		public string Email { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace Kasp.Identity.Core.Entities.UserEntities.XEntities; 

public class LoginVM {
	[Required, EmailAddress]
	public string Email { get; set; }

	[Required]
	public string Password { get; set; }
}
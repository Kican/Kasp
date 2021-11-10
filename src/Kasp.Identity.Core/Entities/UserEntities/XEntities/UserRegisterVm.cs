namespace Kasp.Identity.Core.Entities.UserEntities.XEntities; 

public class UserRegisterVm : IUserRegisterModel {
	public string Email { get; set; }
	public string Password { get; set; }
}
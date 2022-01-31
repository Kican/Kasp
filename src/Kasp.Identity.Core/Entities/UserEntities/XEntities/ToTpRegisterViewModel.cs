using System.ComponentModel.DataAnnotations;

namespace Kasp.Identity.Core.Entities.UserEntities.XEntities; 

public class ToTpRegisterViewModel {
	[Required, Phone]
	public string Phone { get; set; }
}
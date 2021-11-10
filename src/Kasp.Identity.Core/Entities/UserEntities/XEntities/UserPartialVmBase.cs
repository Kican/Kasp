using Kasp.Data.Models.Helpers;

namespace Kasp.Identity.Core.Entities.UserEntities.XEntities; 

public class UserPartialVmBase : IModel {
	public int Id { get; set; }
	public string Name { get; set; }
}
using Kasp.Db.Models;

namespace Kasp.Identity.Entities.UserEntities.XEntities {
	public class UserPartialVmBase : IModel {
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
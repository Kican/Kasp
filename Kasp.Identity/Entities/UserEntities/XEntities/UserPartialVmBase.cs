using Kasp.Db.Models;
using Kasp.Db.Models.Helpers;

namespace Kasp.Identity.Entities.UserEntities.XEntities {
	public class UserPartialVmBase : IModel {
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
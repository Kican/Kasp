using Kasp.Data.Models.Helpers;

namespace Kasp.Panel.UsersManager.Dtos {
	public class RolePartialDto : IModel {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;
using Kasp.Db.Models;
using Kasp.Identity.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Kasp.Identity.Entities.UserEntities {
	public class KaspUser : KaspUserBase, IModel {
	}

	public class KaspRole : IdentityRole<int> {
		public KaspRole() {
		}

		public KaspRole(string name) {
			Name = name;
		}

		[MaxLength(300)]
		public string Description { get; set; }

		[MaxLength(100)]
		public string Title { get; set; }
	}
}
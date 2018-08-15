using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Kasp.Identity.Core.Models {
	public class KaspUserBase : IdentityUser<int> {
		[MaxLength(100)]
		public string Name { get; set; }
	}
}
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Kasp.Identity.Core.Models {
	public class KaspUserBase<TKey> : IdentityUser<TKey> where TKey : unmanaged, IEquatable<TKey> {
		[MaxLength(100)]
		public string Name { get; set; }
	}

	public class KaspUserBase : KaspUserBase<int> {
	}
}
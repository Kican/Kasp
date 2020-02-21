using System;
using Kasp.Data.Models.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Kasp.Identity.Core.Entities.UserEntities {
	public class KaspUser<TKey> : IdentityUser<TKey>, IModel<TKey> where TKey : unmanaged, IEquatable<TKey> {
	}

	public class KaspUser : KaspUser<int> {
	}
}
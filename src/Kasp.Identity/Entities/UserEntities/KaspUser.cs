using System;
using Kasp.Data.Models.Helpers;
using Kasp.Identity.Core.Models;

namespace Kasp.Identity.Entities.UserEntities {
	public class KaspUser<TKey> : KaspUserBase<TKey>, IModel<TKey> where TKey : unmanaged, IEquatable<TKey> {
	}

	public class KaspUser : KaspUser<int> {
	}
}
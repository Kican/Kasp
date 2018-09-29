using System;
using Kasp.EF.Models.Helpers;
using Kasp.Identity.Core.Models;

namespace Kasp.Identity.Entities.UserEntities {
	public class KaspUser<TKey> : KaspUserBase<TKey>, IModel<TKey> where TKey : IEquatable<TKey> {
	}

	public class KaspUser : KaspUser<int> {
	}
}
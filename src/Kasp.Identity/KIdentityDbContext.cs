using System;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.EF.Helpers;
using Kasp.Identity.Core.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Identity {
	public class KIdentityDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey> where TUser : IdentityUser<TKey> where TRole : KaspRole<TKey> where TKey : unmanaged, IEquatable<TKey> {
		public KIdentityDbContext(DbContextOptions options) : base(options) {
		}
	}

	public class KIdentityDbContext<TUser, TRole> : KIdentityDbContext<TUser, TRole, int> where TRole : KaspRole where TUser : IdentityUser<int> {
		public KIdentityDbContext(DbContextOptions options) : base(options) {
		}
	}
}

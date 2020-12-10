﻿using System;
 using System.Linq;
 using System.Linq.Expressions;
 using System.Threading;
using System.Threading.Tasks;
using Kasp.Data;
using Kasp.Data.EF.Data;
using Kasp.Data.EF.Extensions;
using Kasp.Data.Extensions;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Kasp.Identity.Core.Entities.UserEntities;
using Kasp.ObjectMapper.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Identity.Services {
	public class UsersService<TDbContext, TUser, TRole> : EFFilteredRepository<TDbContext, TUser>, IUsersService<TUser>
		where TDbContext : KIdentityDbContext<TUser, TRole>
		where TUser : KaspUser, IModel
		where TRole : KaspRole {
		private readonly UserManager<TUser> _userManager;
		private readonly RoleManager<TRole> _roleManager;

		public UsersService(TDbContext db, UserManager<TUser> userManager, RoleManager<TRole> roleManager) : base(db) {
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async ValueTask<T[]> GetRolesAsync<T>(CancellationToken token = default) {
			return await _roleManager.Roles.MapTo<T>().ToArrayAsync(token);
		}

		public async ValueTask<T[]> GetUserRolesAsync<T>(int userId, CancellationToken token = default) {
			var userRoles = await Db.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId).ToArrayAsync(token);
			return await Db.Roles.Where(x => userRoles.Contains(x.Id)).MapTo<T>().ToArrayAsync(cancellationToken: token);		}

		public async Task<IdentityResult> SetUserPasswordAsync(int userId, string password, CancellationToken cancellationToken = default) {
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

			await _userManager.RemovePasswordAsync(user);
			return await _userManager.AddPasswordAsync(user, password);
		}

		public async Task<IdentityResult> SetUserEmailAsync(int userId, string email, CancellationToken cancellationToken = default) {
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
			return await _userManager.SetEmailAsync(user, email);
		}

		public async Task<IdentityResult> SetUserRolesAsync(int userId, string[] roles, CancellationToken cancellationToken = default) {
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
			var userRoles = await _userManager.GetRolesAsync(user);
			await _userManager.RemoveFromRolesAsync(user, userRoles);
			return await _userManager.AddToRolesAsync(user, roles);
		}

		public override async Task<IPagedList<TOutput>> FilterAsync<TOutput>(FilterBase filter, CancellationToken cancellationToken = default) {
			var query = BaseQuery.AsNoTracking();

			if (!string.IsNullOrEmpty(filter.Q))
				query = query.Where(x =>
					EF.Functions.Like(x.UserName, $"%{filter.Q}%") ||
					EF.Functions.Like(x.Email, $"%{filter.Q}%")
				);


			return await query.MapTo<TOutput>().SortBy(filter).ToPagedListAsync(filter.Count, filter.Page, cancellationToken);
		}
	}
}

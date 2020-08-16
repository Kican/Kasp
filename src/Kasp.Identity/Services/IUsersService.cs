﻿using System.Threading;
using System.Threading.Tasks;
using Kasp.Data;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Kasp.Identity.Core.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;

namespace Kasp.Identity.Services {
	public interface IUsersService<TUser> : IFilteredRepositoryBase<TUser, FilterBase>
		where TUser : KaspUser, IModel {
		ValueTask<T[]> GetRolesAsync<T>(CancellationToken token = default);
		ValueTask<T[]> GetUserRolesAsync<T>(int userId, CancellationToken token = default);
		Task<IdentityResult> SetUserPasswordAsync(int userId, string password, CancellationToken cancellationToken = default);
		Task<IdentityResult> SetUserEmailAsync(int userId, string email, CancellationToken cancellationToken = default);
		Task<IdentityResult> SetUserRolesAsync(int userId, string[] roles, CancellationToken cancellationToken = default);
	}
}
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Data.EF.Data;

public abstract class EFFilteredRepository<TDbContext, TModel, TKey, TFilter> : EFBaseRepository<TDbContext, TModel, TKey>, IEFFilteredRepository<TModel, TKey, TFilter>
	where TKey : IEquatable<TKey> where TModel : class, IModel<TKey> where TDbContext : DbContext where TFilter : FilterBase {
	public EFFilteredRepository(TDbContext db) : base(db) {
	}


	public abstract Task<IPagedList<TOutput>> FilterAsync<TOutput>(TFilter filter, CancellationToken cancellationToken = default);

	public virtual Task<IPagedList<TProject>> FilterAsync<TProject>(TFilter filter, Expression<Func<TModel, TProject>> projection, CancellationToken cancellationToken = default) {
		throw new NotImplementedException();
	}
}

public abstract class EFFilteredRepository<TDbContext, TModel, TFilter> : EFFilteredRepository<TDbContext, TModel, int, TFilter>
	where TModel : class, IModel<int> where TDbContext : DbContext where TFilter : FilterBase {
	public EFFilteredRepository(TDbContext db) : base(db) {
	}
}

public abstract class EFFilteredRepository<TDbContext, TModel> : EFFilteredRepository<TDbContext, TModel, FilterBase> where TModel : class, IModel<int> where TDbContext : DbContext {
	protected EFFilteredRepository(TDbContext db) : base(db) {
	}
}

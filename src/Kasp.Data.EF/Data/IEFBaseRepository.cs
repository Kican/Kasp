using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.EF.Models;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Data.EF.Data {
	public interface IEFBaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey> where TModel : class, IModel<TKey> where TKey : IEquatable<TKey> {
		DbSet<TModel> Set { get; }
		IQueryable<TModel> BaseQuery { get; }


		ValueTask<TProject> GetAsync<TProject>(TKey id, Expression<Func<TModel, TProject>> projection, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;

		ValueTask<TProject> GetAsync<TProject>(Expression<Func<TModel, bool>> filter, Expression<Func<TModel, TProject>> projection, CancellationToken cancellationToken = default);


		ValueTask<IEnumerable<TProject>> ListAsync<TProject>(Expression<Func<TModel, TProject>> projection, CancellationToken cancellationToken = default);

		ValueTask<IEnumerable<TProject>> ListAsync<TProject>(
			Expression<Func<TModel, bool>> expression,
			Expression<Func<TModel, TProject>> projection,
			CancellationToken cancellationToken = default
		);

		ValueTask<IPagedList<TProject>> PagedListAsync<TProject>(
			Expression<Func<TModel, bool>> expression,
			Expression<Func<TModel, TProject>> projection,
			int page = 1,
			int count = 20,
			CancellationToken cancellationToken = default
		);

		ValueTask<IPagedList<TProject>> PagedListAsync<TProject>(
			Expression<Func<TModel, TProject>> projection,
			int page = 1,
			int count = 20,
			CancellationToken cancellationToken = default
		) where TProject : IModel<TKey>;
	}

	public interface IEFBaseRepository<TModel> : IEFBaseRepository<TModel, int> where TModel : class, IModel {
	}
}

using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;

namespace Kasp.Data {
	public interface IFilteredRepositoryBase<TModel, TKey, TFilter> : IBaseRepository<TModel, TKey>
		where TModel : class, IModel<TKey>
		where TKey : IEquatable<TKey>
		where TFilter : FilterBase {
		Task<IPagedList<TProject>> FilterAsync<TProject>(TFilter filter, CancellationToken cancellationToken = default);
		Task<IPagedList<TProject>> FilterAsync<TProject>(TFilter filter, Expression<Func<TModel, TProject>> projection, CancellationToken cancellationToken = default);
	}

	public interface IFilteredRepositoryBase<TModel, TFilter> : IFilteredRepositoryBase<TModel, int, TFilter>
		where TFilter : FilterBase
		where TModel : class, IModel {
	}
}

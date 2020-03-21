using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.Models.Helpers;

namespace Kasp.Data {
	public interface IBaseRepository<TModel, TKey> where TModel : class, IModel<TKey> where TKey : IEquatable<TKey> {
		// is exist
		ValueTask<bool> HasAsync(TKey id, CancellationToken cancellationToken = default);
		ValueTask<bool> HasAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default);

		// get one item
		ValueTask<TModel> GetAsync(TKey id, CancellationToken cancellationToken = default);
		ValueTask<TProject> GetAsync<TProject>(TKey id, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;
		ValueTask<TModel> GetAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default);

		ValueTask<TProject> GetAsync<TProject>(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;
		// lists
//		Task<ICollection<TModel>> ListAsync(IPage page, CancellationToken cancellationToken = default);
//		Task<ICollection<TModel>> ListAsync(ISort sort, CancellationToken cancellationToken = default);
//		Task<ICollection<TModel>> ListAsync(IPage page, ISort sort, CancellationToken cancellationToken = default);

		ValueTask<IEnumerable<TModel>> ListAsync(CancellationToken cancellationToken = default);
		ValueTask<IEnumerable<TProject>> ListAsync<TProject>(CancellationToken cancellationToken = default) where TProject : IModel<TKey>;
		ValueTask<IEnumerable<TModel>> ListAsync(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default);
		ValueTask<IEnumerable<TProject>> ListAsync<TProject>(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;

		// paged list
		ValueTask<IPagedList<TModel>> PagedListAsync(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default);

		ValueTask<IPagedList<TProject>> PagedListAsync<TProject>(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default)
			where TProject : IModel<TKey>;

		ValueTask<IPagedList<TModel>> PagedListAsync(int page = 1, int count = 20, CancellationToken cancellationToken = default);
		ValueTask<IPagedList<TProject>> PagedListAsync<TProject>(int page = 1, int count = 20, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;

		Task AddAsync(TModel model, CancellationToken cancellationToken = default);
		Task AddAsync(IEnumerable<TModel> model, CancellationToken cancellationToken = default);

		Task UpdateAsync(TModel model, CancellationToken cancellationToken = default);
		Task UpdateRangeAsync(IEnumerable<TModel> items, CancellationToken cancellationToken = default);

		Task RemoveAsync(TKey id, CancellationToken cancellationToken = default);
		Task RemoveAsync(TModel model, CancellationToken cancellationToken = default);
	}

	public interface IBaseRepository<TModel> : IBaseRepository<TModel, int> where TModel : class, IModel<int> {
	}
}
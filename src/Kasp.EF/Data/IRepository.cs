using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.Models;
using Kasp.EF.Models;
using Kasp.EF.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kasp.EF.Data {
	public interface IBaseRepository<TModel, TKey> where TModel : class, IModel<TKey> {
		DbSet<TModel> Set { get; }
		IQueryable<TModel> BaseQuery { get; }

		// is exist
		Task<bool> HasAsync(TKey id, CancellationToken cancellationToken = default);
		Task<bool> HasAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default);
		Task<bool> HasFilteredAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default);

		// get one item
		Task<TModel> GetAsync(TKey id, CancellationToken cancellationToken = default);
		Task<TModel> GetFilteredAsync(TKey id, CancellationToken cancellationToken = default);

		Task<TProject> GetAsync<TProject>(TKey id, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;
		Task<TProject> GetFilteredAsync<TProject>(TKey id, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;

		Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default);
		Task<TModel> GetFilteredAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default);
		Task<TProject> GetAsync<TProject>(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;
		Task<TProject> GetFilteredAsync<TProject>(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;

		// lists
//		Task<ICollection<TModel>> ListAsync(IPage page, CancellationToken cancellationToken = default);
//		Task<ICollection<TModel>> ListAsync(ISort sort, CancellationToken cancellationToken = default);
//		Task<ICollection<TModel>> ListAsync(IPage page, ISort sort, CancellationToken cancellationToken = default);

		Task<ICollection<TModel>> ListAsync(CancellationToken cancellationToken = default);
		Task<ICollection<TModel>> ListFilteredAsync(CancellationToken cancellationToken = default);
		Task<ICollection<TProject>> ListAsync<TProject>(CancellationToken cancellationToken = default) where TProject : IModel<TKey>;
		Task<ICollection<TProject>> ListFilteredAsync<TProject>(CancellationToken cancellationToken = default) where TProject : IModel<TKey>;

		Task<ICollection<TModel>> ListAsync(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default);
		Task<ICollection<TModel>> ListFilteredAsync(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default);
		Task<ICollection<TProject>> ListAsync<TProject>(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;
		Task<ICollection<TProject>> ListFilteredAsync<TProject>(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;

		// paged list
		Task<IPagedList<TModel>> PagedListAsync(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default);
		Task<IPagedList<TModel>> PagedListFilteredAsync(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default);

		Task<IPagedList<TProject>> PagedListAsync<TProject>(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default)
			where TProject : IModel<TKey>;

		Task<IPagedList<TProject>> PagedListFilteredAsync<TProject>(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default)
			where TProject : IModel<TKey>;


		Task<IPagedList<TModel>> PagedListAsync(int page = 1, int count = 20, CancellationToken cancellationToken = default);
		Task<IPagedList<TModel>> PagedListFilteredAsync(int page = 1, int count = 20, CancellationToken cancellationToken = default);
		Task<IPagedList<TProject>> PagedListAsync<TProject>(int page = 1, int count = 20, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;
		Task<IPagedList<TProject>> PagedListFilteredAsync<TProject>(int page = 1, int count = 20, CancellationToken cancellationToken = default) where TProject : IModel<TKey>;

		Task AddAsync(TModel model, CancellationToken cancellationToken = default);
		Task AddAsync(IEnumerable<TModel> model, CancellationToken cancellationToken = default);

		void Update(TModel model);

		Task RemoveAsync(TKey id, CancellationToken cancellationToken = default);
		void Remove(TModel model);

		Task<int> SaveAsync(CancellationToken cancellationToken = default);
	}

	public interface IBaseRepository<TModel> : IBaseRepository<TModel, int> where TModel : class, IModel {
	}
}
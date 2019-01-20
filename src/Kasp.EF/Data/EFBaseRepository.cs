using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Kasp.EF.Extensions;
using Kasp.EF.Helpers;
using Kasp.EF.Models;
using Kasp.EF.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kasp.EF.Data {
	public abstract class EFBaseRepository<TDbContext, TModel, TKey> : IBaseRepository<TModel, TKey>
		where TDbContext : DbContext
		where TModel : class, IModel<TKey> {
		protected EFBaseRepository(TDbContext db) {
			Db = db;
			Set = db.Set<TModel>();
		}

		public DbSet<TModel> Set { get; }
		public virtual IQueryable<TModel> BaseQuery => Set.AsQueryable();

		public virtual async Task<bool> HasAsync(TKey id, CancellationToken cancellationToken = default) {
			return await BaseQuery.AnyAsync(x => x.Id.Equals(id), cancellationToken);
		}

		public virtual async Task<bool> HasAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) {
			return await BaseQuery.AnyAsync(filter, cancellationToken);
		}

		public virtual async Task<bool> HasFilteredAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) {
			return await FilteredQuery.AnyAsync(filter, cancellationToken);
		}

		public virtual async Task<TModel> GetAsync(TKey id, CancellationToken cancellationToken = default) {
			return await BaseQuery.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
		}

		public virtual async Task<TModel> GetFilteredAsync(TKey id, CancellationToken cancellationToken = default) {
			return await FilteredQuery.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
		}

		public virtual async Task<TProject> GetAsync<TProject>(TKey id, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await BaseQuery.ProjectTo<TProject>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
		}

		public virtual async Task<TProject> GetFilteredAsync<TProject>(TKey id, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await FilteredQuery.ProjectTo<TProject>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
		}

		public virtual async Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) {
			return await BaseQuery.FirstOrDefaultAsync(filter, cancellationToken);
		}

		public virtual async Task<TModel> GetFilteredAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) {
			return await FilteredQuery.FirstOrDefaultAsync(filter, cancellationToken);
		}

		public virtual async Task<TProject> GetAsync<TProject>(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await BaseQuery.Where(filter).ProjectTo<TProject>().FirstOrDefaultAsync(cancellationToken);
		}

		public virtual async Task<TProject> GetFilteredAsync<TProject>(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await FilteredQuery.Where(filter).ProjectTo<TProject>().FirstOrDefaultAsync(cancellationToken);
		}

		public virtual async Task<ICollection<TModel>> ListAsync(CancellationToken cancellationToken = default) {
			return await BaseQuery.ToArrayAsync(cancellationToken);
		}

		public virtual async Task<ICollection<TModel>> ListFilteredAsync(CancellationToken cancellationToken = default) {
			return await FilteredQuery.ToArrayAsync(cancellationToken);
		}

		public virtual async Task<ICollection<TProject>> ListAsync<TProject>(CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await BaseQuery.ProjectTo<TProject>().ToArrayAsync(cancellationToken);
		}

		public virtual async Task<ICollection<TProject>> ListFilteredAsync<TProject>(CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await FilteredQuery.ProjectTo<TProject>().ToArrayAsync(cancellationToken);
		}

		public virtual async Task<ICollection<TModel>> ListAsync(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default) {
			return await BaseQuery.Where(expression).ToArrayAsync(cancellationToken);
		}

		public virtual async Task<ICollection<TModel>> ListFilteredAsync(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default) {
			return await FilteredQuery.Where(expression).ToArrayAsync(cancellationToken);
		}

		public virtual async Task<ICollection<TProject>> ListAsync<TProject>(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await BaseQuery.Where(expression).ProjectTo<TProject>().ToArrayAsync(cancellationToken);
		}

		public virtual async Task<ICollection<TProject>> ListFilteredAsync<TProject>(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await FilteredQuery.Where(expression).ProjectTo<TProject>().ToArrayAsync(cancellationToken);
		}

		public virtual async Task<IPagedList<TModel>> PagedListAsync(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default) {
			return await BaseQuery.Where(expression).ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async Task<IPagedList<TModel>> PagedListFilteredAsync(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default) {
			return await FilteredQuery.Where(expression).ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async Task<IPagedList<TProject>> PagedListAsync<TProject>(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default)
			where TProject : IModel<TKey> {
			return await BaseQuery.Where(expression).ProjectTo<TProject>().ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async Task<IPagedList<TProject>> PagedListFilteredAsync<TProject>(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default)
			where TProject : IModel<TKey> {
			return await FilteredQuery.Where(expression).ProjectTo<TProject>().ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async Task<IPagedList<TModel>> PagedListAsync(int page = 1, int count = 20, CancellationToken cancellationToken = default) {
			return await BaseQuery.ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async Task<IPagedList<TModel>> PagedListFilteredAsync(int page = 1, int count = 20, CancellationToken cancellationToken = default) {
			return await FilteredQuery.ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async Task<IPagedList<TProject>> PagedListAsync<TProject>(int page = 1, int count = 20, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await BaseQuery.ProjectTo<TProject>().ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async Task<IPagedList<TProject>> PagedListFilteredAsync<TProject>(int page = 1, int count = 20, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await FilteredQuery.ProjectTo<TProject>().ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async Task AddAsync(TModel model, CancellationToken cancellationToken = default) {
			await Set.AddAsync(model, cancellationToken);
		}

		public virtual async Task AddAsync(IEnumerable<TModel> model, CancellationToken cancellationToken = default) {
			await Set.AddRangeAsync(model, cancellationToken);
		}

		public virtual void Update(TModel model) {
			Set.Update(model);
		}

		public virtual async Task RemoveAsync(TKey id, CancellationToken cancellationToken = default) {
			var model = await GetAsync(id, cancellationToken);
			Set.Remove(model);
		}

		public virtual void Remove(TModel model) {
			Set.Remove(model);
		}

		public async Task<int> SaveAsync(CancellationToken cancellationToken = default) {
			return await Db.SaveChangesAsync(cancellationToken);
		}

		private IQueryable<TModel> _filteredQuery;

		public IQueryable<TModel> FilteredQuery {
			get {
				if (_filteredQuery != null) return _filteredQuery;

				var query = BaseQuery;
				EntityHelperFactory.GetQueryFilter<TModel>().ForEach(helper => query = helper.QueryFilter(query));
				_filteredQuery = query;

				return _filteredQuery;
			}
		}

		public TDbContext Db { get; }
	}

	public abstract class IefEfBaseRepository<TDbContext, TModel> : EFBaseRepository<TDbContext, TModel, int>, IEFBaseRepository<TModel> where TModel : class, IModel where TDbContext : DbContext {
		protected IefEfBaseRepository(TDbContext db) : base(db) {
		}
	}
}
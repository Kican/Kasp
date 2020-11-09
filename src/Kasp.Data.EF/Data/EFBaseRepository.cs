using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.EF.Extensions;
using Kasp.Data.Extensions;
using Kasp.Data.Models.Helpers;
using Kasp.ObjectMapper.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Data.EF.Data {
	public abstract class EFBaseRepository<TDbContext, TModel, TKey> : IEFBaseRepository<TModel, TKey>
		where TDbContext : DbContext
		where TModel : class, IModel<TKey>
		where TKey : IEquatable<TKey> {
		protected EFBaseRepository(TDbContext db) {
			Db = db;
			Set = db.Set<TModel>();
		}

		public DbSet<TModel> Set { get; }
		public virtual IQueryable<TModel> BaseQuery => Set.AsQueryable();

		public virtual async ValueTask<bool> HasAsync(TKey id, CancellationToken cancellationToken = default) {
			return await BaseQuery.AnyAsync(x => x.Id.Equals(id), cancellationToken);
		}

		public virtual async ValueTask<bool> HasAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) {
			return await BaseQuery.AnyAsync(filter, cancellationToken);
		}


		public virtual async ValueTask<TModel> GetAsync(TKey id, CancellationToken cancellationToken = default) {
			return await BaseQuery.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
		}

		public virtual async ValueTask<TProject> GetAsync<TProject>(TKey id, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await BaseQuery.MapTo<TProject>().WhereIdEquals(x => x.Id, id).FirstOrDefaultAsync(cancellationToken);
		}

		public virtual async ValueTask<TModel> GetAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) {
			return await BaseQuery.FirstOrDefaultAsync(filter, cancellationToken);
		}

		public virtual async ValueTask<TKey> GetIdAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) {
			return await BaseQuery.Where(filter).Select(x => x.Id).FirstOrDefaultAsync(cancellationToken);
		}

		public virtual async ValueTask<TProject> GetAsync<TProject>(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await BaseQuery.Where(filter).MapTo<TProject>().FirstOrDefaultAsync(cancellationToken);
		}

		public virtual async ValueTask<IEnumerable<TModel>> ListAsync(CancellationToken cancellationToken = default) {
			return await BaseQuery.ToArrayAsync(cancellationToken);
		}

		public virtual async ValueTask<IEnumerable<TProject>> ListAsync<TProject>(CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await BaseQuery.MapTo<TProject>().ToArrayAsync(cancellationToken);
		}

		public virtual async ValueTask<IEnumerable<TModel>> ListAsync(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default) {
			return await BaseQuery.Where(expression).ToArrayAsync(cancellationToken);
		}

		public virtual async ValueTask<IEnumerable<TProject>> ListAsync<TProject>(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default)
			where TProject : IModel<TKey> {
			return await BaseQuery.Where(expression).MapTo<TProject>().ToArrayAsync(cancellationToken);
		}

		public virtual async ValueTask<IPagedList<TModel>> PagedListAsync(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default) {
			return await BaseQuery.Where(expression).ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async ValueTask<IPagedList<TProject>> PagedListAsync<TProject>(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20,
			CancellationToken cancellationToken = default)
			where TProject : IModel<TKey> {
			return await BaseQuery.Where(expression).MapTo<TProject>().ToPagedListAsync(count, page, cancellationToken);
		}

		public virtual async ValueTask<IPagedList<TModel>> PagedListAsync(int page = 1, int count = 20, CancellationToken cancellationToken = default) {
			return await BaseQuery.ToPagedListAsync(count, page, cancellationToken);
		}


		public virtual async ValueTask<IPagedList<TProject>> PagedListAsync<TProject>(int page = 1, int count = 20, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			return await BaseQuery.MapTo<TProject>().ToPagedListAsync(count, page, cancellationToken);
		}


		public virtual async Task AddAsync(TModel model, CancellationToken cancellationToken = default) {
			await Set.AddAsync(model, cancellationToken);
			await SaveAsync(cancellationToken);
		}

		public virtual async Task AddAsync(IEnumerable<TModel> model, CancellationToken cancellationToken = default) {
			await Set.AddRangeAsync(model, cancellationToken);
			await SaveAsync(cancellationToken);
		}

		public async Task UpdateAsync(TModel model, CancellationToken cancellationToken = default) {
			Set.Update(model);
			await SaveAsync(cancellationToken);
		}

		public async Task UpdateRangeAsync(IEnumerable<TModel> items, CancellationToken cancellationToken = default) {
			Set.UpdateRange(items);
			await SaveAsync(cancellationToken);
		}

		public virtual async Task RemoveAsync(TKey id, CancellationToken cancellationToken = default) {
			var model = await GetAsync(id, cancellationToken);
			Set.Remove(model);
			await SaveAsync(cancellationToken);
		}

		public async Task RemoveAsync(TModel model, CancellationToken cancellationToken = default) {
			Set.Remove(model);
			await SaveAsync(cancellationToken);
		}

		public async ValueTask<int> SaveAsync(CancellationToken cancellationToken = default) {
			return await Db.SaveChangesAsync(cancellationToken);
		}

		public TDbContext Db { get; }
	}

	public abstract class EFBaseRepository<TDbContext, TModel> : EFBaseRepository<TDbContext, TModel, int>, IEFBaseRepository<TModel> where TModel : class, IModel where TDbContext : DbContext {
		protected EFBaseRepository(TDbContext db) : base(db) {
		}
	}
}
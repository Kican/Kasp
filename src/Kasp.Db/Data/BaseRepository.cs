using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Kasp.Db.Extensions;
using Kasp.Db.Models;
using Kasp.Db.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Db.Data {
	public abstract class BaseRepository<TDbContext, TModel, TKey> : IBaseRepository<TModel, TKey>
		where TDbContext : DbContext
		where TModel : class, IModel<TKey> {
		protected BaseRepository(TDbContext db) {
			Db = db;
			Set = db.Set<TModel>();
		}

		public DbSet<TModel> Set { get; }
		public virtual IQueryable<TModel> BaseQuery => Set.AsQueryable();

		public TDbContext Db { get; }

		public async Task<bool> HasAsync(TKey id, CancellationToken cancellationToken = default) =>
			await BaseQuery.AnyAsync(x => x.Id.Equals(id), cancellationToken);

		public async Task<bool> HasAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) =>
			await BaseQuery.AnyAsync(filter, cancellationToken);


		// get item with id
		public async Task<TModel> GetAsync(TKey id, CancellationToken cancellationToken = default) =>
			await BaseQuery.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

		public async Task<TProject> GetAsync<TProject>(TKey id, CancellationToken cancellationToken = default) where TProject : IModel<TKey> =>
			await BaseQuery.ProjectTo<TProject>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

		// get item with condition
		public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter, CancellationToken cancellationToken = default) =>
			await BaseQuery.FirstOrDefaultAsync(filter, cancellationToken);

		public async Task<TProject> GetAsync<TProject>(Expression<Func<TProject, bool>> filter, CancellationToken cancellationToken = default) where TProject : IModel<TKey> =>
			await BaseQuery.ProjectTo<TProject>().FirstOrDefaultAsync(filter, cancellationToken);


		public Task<TModel> GetAsync(ISpecification<TModel, TKey> specification, CancellationToken cancellationToken = default) {
			throw new NotImplementedException();
		}

		public Task<TProject> GetAsync<TProject>(ISpecification<TModel, TKey> specification, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			throw new NotImplementedException();
		}

		public async Task<ICollection<TModel>> ListAsync(CancellationToken cancellationToken = default) =>
			await BaseQuery.ToArrayAsync(cancellationToken);

		public async Task<ICollection<TProject>> ListAsync<TProject>(CancellationToken cancellationToken = default) where TProject : IModel<TKey> =>
			await BaseQuery.ProjectTo<TProject>().ToArrayAsync(cancellationToken);

		public Task<ICollection<TModel>> ListAsync(ISpecification<TModel, TKey> specification, CancellationToken cancellationToken = default) {
			throw new NotImplementedException();
		}

		public Task<ICollection<TProject>> ListAsync<TProject>(ISpecification<TModel, TKey> specification, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			throw new NotImplementedException();
		}

		public async Task<ICollection<TModel>> ListAsync(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default) =>
			await BaseQuery.Where(expression).ToArrayAsync(cancellationToken);

		public async Task<ICollection<TProject>> ListAsync<TProject>(Expression<Func<TProject, bool>> expression, CancellationToken cancellationToken = default) where TProject : IModel<TKey> =>
			await BaseQuery.ProjectTo<TProject>().Where(expression).ToArrayAsync(cancellationToken);


		public async Task<IPagedList<TModel>> PagedListAsync(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default) =>
			await BaseQuery.Where(expression).ToPagedListAsync(count, page, cancellationToken);

		public async Task<IPagedList<TProject>> PagedListAsync<TProject>(Expression<Func<TProject, bool>> expression, int page = 1, int count = 20, CancellationToken cancellationToken = default) where TProject : IModel<TKey> =>
			await BaseQuery.ProjectTo<TProject>().Where(expression).ToPagedListAsync(count, page, cancellationToken);

		public Task<IPagedList<TModel>> PagedListAsync(ISpecification<TModel, TKey> specification, int page = 1, int count = 20, CancellationToken cancellationToken = default) {
			throw new NotImplementedException();
		}

		public Task<IPagedList<TProject>> PagedListAsync<TProject>(ISpecification<TModel, TKey> specification, int page = 1, int count = 20, CancellationToken cancellationToken = default) where TProject : IModel<TKey> {
			throw new NotImplementedException();
		}

		public async Task<IPagedList<TModel>> PagedListAsync(int page = 1, int count = 20, CancellationToken cancellationToken = default) => await BaseQuery.ToPagedListAsync(count, page, cancellationToken);

		public async Task<IPagedList<TProject>> PagedListAsync<TProject>(int page = 1, int count = 20, CancellationToken cancellationToken = default) where TProject : IModel<TKey> =>
			await BaseQuery.ProjectTo<TProject>().ToPagedListAsync(count, page, cancellationToken);

		public async Task AddAsync(TModel model, CancellationToken cancellationToken = default) => await Set.AddAsync(model, cancellationToken);

		public async Task AddAsync(IEnumerable<TModel> model, CancellationToken cancellationToken = default) => await Set.AddRangeAsync(model, cancellationToken);

		public void Update(TModel model) => Set.Update(model);

		public async Task RemoveAsync(TKey id, CancellationToken cancellationToken = default) {
			var model = await GetAsync(id, cancellationToken);
			Set.Remove(model);
		}

		public void Remove(TModel model) => Set.Remove(model);

		public async Task<int> SaveAsync(CancellationToken cancellationToken = default) =>
			await Db.SaveChangesAsync(cancellationToken);
	}

	public abstract class BaseRepository<TDbContext, TModel> : BaseRepository<TDbContext, TModel, int>, IBaseRepository<TModel> where TModel : class, IModel where TDbContext : DbContext {
		protected BaseRepository(TDbContext db) : base(db) {
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kasp.Db.Models;
using Kasp.Db.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Db.Data {
	public abstract class BaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey> where TModel : class, IModel<TKey> {
		public DbSet<TModel> Set { get; }
		public IQueryable<TModel> BaseQuery { get; set; }

		public void ChangeQuery(IQueryable<TModel> query) {
			throw new NotImplementedException();
		}

		public Task<bool> HasAsync(TKey id) {
			throw new NotImplementedException();
		}

		public Task<bool> HasAsync(Expression<Func<TModel, bool>> filter) {
			throw new NotImplementedException();
		}

		public Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter) {
			throw new NotImplementedException();
		}

		public Task<TModel> GetAsync(TKey id) {
			throw new NotImplementedException();
		}

		public Task<TProject> GetAsync<TProject>(Expression<Func<TProject, bool>> filter) where TProject : IModel<TKey> {
			throw new NotImplementedException();
		}

		public Task<TProject> GetAsync<TProject>(TKey id) where TProject : IModel<TKey> {
			throw new NotImplementedException();
		}

		public Task<ICollection<TModel>> ListAsync() {
			throw new NotImplementedException();
		}

		public Task<ICollection<TProject>> ListAsync<TProject>() where TProject : IModel<TKey> {
			throw new NotImplementedException();
		}

		public Task<ICollection<TModel>> ListAsync(Expression<Func<TModel, bool>> expression) {
			throw new NotImplementedException();
		}

		public Task<ICollection<TProject>> ListAsync<TProject>(Expression<Func<TProject, bool>> expression) where TProject : IModel<TKey> {
			throw new NotImplementedException();
		}

		public Task<IPagedList<TModel>> PagedListAsync(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20) {
			throw new NotImplementedException();
		}

		public Task<IPagedList<TProject>> PagedListAsync<TProject>(Expression<Func<TProject, bool>> expression, int page = 1, int count = 20) where TProject : IModel<TKey> {
			throw new NotImplementedException();
		}

		public Task<IPagedList<TModel>> PagedListAsync(int page = 1, int count = 20) {
			throw new NotImplementedException();
		}

		public Task<IPagedList<TProject>> PagedListAsync<TProject>(int page = 1, int count = 20) where TProject : IModel<TKey> {
			throw new NotImplementedException();
		}

		public Task AddAsync(TModel model) {
			throw new NotImplementedException();
		}

		public Task AddAsync(IEnumerable<TModel> model) {
			throw new NotImplementedException();
		}

		public void UpdateAsync(TModel model) {
			throw new NotImplementedException();
		}

		public Task RemoveAsync(TKey id) {
			throw new NotImplementedException();
		}

		public void Remove(TModel model) {
			throw new NotImplementedException();
		}

		public Task<int> SaveAsync() {
			throw new NotImplementedException();
		}
	}
}
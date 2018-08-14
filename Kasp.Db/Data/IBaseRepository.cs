using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kasp.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Db.Data {
	public interface IBaseRepository<TModel, TKey> where TModel : class, IModel {
		DbSet<TModel> Set { get; }
		IQueryable<TModel> BaseQuery { get; set; }

		void ChangeQuery(IQueryable<TModel> query);

		Task<bool> HasAsync(TKey id);
		Task<bool> HasAsync(Expression<Func<TModel, bool>> filter);

		Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter);
		Task<TModel> GetAsync(TKey id);

		Task<TProject> GetAsync<TProject>(Expression<Func<TProject, bool>> filter) where TProject : IModel<TKey>;
		Task<TProject> GetAsync<TProject>(TKey id) where TProject : IModel<TKey>;

		Task<ICollection<TModel>> ListAsync();
		Task<ICollection<TProject>> ListAsync<TProject>() where TProject : IModel<TKey>;
		Task<ICollection<TModel>> ListAsync(Expression<Func<TModel, bool>> expression);
		Task<ICollection<TProject>> ListAsync<TProject>(Expression<Func<TProject, bool>> expression) where TProject : IModel<TKey>;


		Task<IPagedList<TModel>> PagedListAsync(Expression<Func<TModel, bool>> expression, int page = 1, int count = 20);
		Task<IPagedList<TProject>> PagedListAsync<TProject>(Expression<Func<TProject, bool>> expression, int page = 1, int count = 20) where TProject : IModel<TKey>;
		Task<IPagedList<TModel>> PagedListAsync(int page = 1, int count = 20);
		Task<IPagedList<TProject>> PagedListAsync<TProject>(int page = 1, int count = 20) where TProject : IModel<TKey>;

		Task AddAsync(TModel model);
		Task AddAsync(IEnumerable<TModel> model);

		void Update(TModel model);

		Task RemoveAsync(TKey id);
		void Remove(TModel model);

		Task<int> SaveAsync();
	}

	public interface IBaseRepository<TModel> : IBaseRepository<TModel, int> where TModel : class, IModel {
	}
}
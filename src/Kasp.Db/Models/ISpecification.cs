using System.Linq;
using Kasp.Db.Models.Helpers;

namespace Kasp.Db.Models {
	public interface ISpecification<TModel, TKey> where TModel : IModel<TKey> {
		IQueryable<TModel> Query { get; set; }
	}

	public interface ISpecification<TModel> : ISpecification<TModel, int> where TModel : IModel {
	}
}
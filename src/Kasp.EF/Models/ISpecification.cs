using System.Linq;
using Kasp.EF.Models.Helpers;

namespace Kasp.EF.Models {
	public interface ISpecification<TModel, TKey> where TModel : IModel<TKey> {
		IQueryable<TModel> Query { get; set; }
	}

	public interface ISpecification<TModel> : ISpecification<TModel, int> where TModel : IModel {
	}
}
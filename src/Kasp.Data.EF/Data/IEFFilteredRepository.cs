using System;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;

namespace Kasp.Data.EF.Data {
	public interface IEFFilteredRepository<TModel, TKey, TFilter> : IFilteredRepositoryBase<TModel, TKey, TFilter>
		where TFilter : FilterBase
		where TKey : IEquatable<TKey>
		where TModel : class, IModel<TKey> {
	}

	public interface IEFFilteredRepository<TModel, TFilter> : IEFFilteredRepository<TModel, int, TFilter> where TFilter : FilterBase where TModel : class, IModel {
	};
}

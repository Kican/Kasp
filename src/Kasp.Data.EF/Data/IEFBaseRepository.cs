using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.EF.Models;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Data.EF.Data {
	public interface IEFBaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey> where TModel : class, IModel<TKey> where TKey : IEquatable<TKey> {
		DbSet<TModel> Set { get; }
		IQueryable<TModel> BaseQuery { get; }
	}

	public interface IEFBaseRepository<TModel> : IEFBaseRepository<TModel, int> where TModel : class, IModel {
	}
}
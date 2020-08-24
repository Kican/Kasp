using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;

namespace Kasp.Data.Extensions {
	public static class QueryExtensions {
		public static IQueryable<T> SortBy<T>(this IQueryable<T> queryable, FilterBase filter) {
			if (!string.IsNullOrEmpty(filter.OrderBy))
				queryable = queryable.OrderBy(filter.OrderBy + " " + (filter.IsDesc ? "desc" : ""));

			return queryable;
		}

		public static IQueryable<TEntity> WhereIdEquals<TEntity, TKey>(this IQueryable<TEntity> source, Expression<Func<TEntity, TKey>> keyExpression, TKey otherKeyValue)
			where TEntity : IModel<TKey> where TKey : IEquatable<TKey> {
			var memberExpression = (MemberExpression) keyExpression.Body;
			var parameter = Expression.Parameter(typeof(TEntity), "x");
			var property = Expression.Property(parameter, memberExpression.Member.Name);
			var equal = Expression.Equal(property, Expression.Constant(otherKeyValue));
			var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, parameter);
			return source.Where(lambda);
		}
	}
}
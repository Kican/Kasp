using System;
using System.Linq.Expressions;

namespace Kasp.Data.Specification {
	public interface ISpecification<T> {
		Expression<Func<T, bool>> ToExpression();
	}
}

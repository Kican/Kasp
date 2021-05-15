using System;
using System.Linq.Expressions;

namespace Kasp.Data.Specification {
	public abstract class Specification<T> : ISpecification<T> {
		public abstract Expression<Func<T, bool>> ToExpression();

		public static implicit operator Expression<Func<T, bool>>(Specification<T> specification) {
			return specification.ToExpression();
		}

		public static implicit operator Func<T, bool>(Specification<T> specification) {
			return specification.ToExpression().Compile();
		}
	}
}

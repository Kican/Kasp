using System;
using System.Linq.Expressions;

namespace Kasp.Data.Specification {
	public class ExpressionSpecification<T> : Specification<T> {
		private readonly Expression<Func<T, bool>> _expression;


		public ExpressionSpecification(Expression<Func<T, bool>> expression) {
			_expression = expression;
		}

		public override Expression<Func<T, bool>> ToExpression() {
			return _expression;
		}
	}
}

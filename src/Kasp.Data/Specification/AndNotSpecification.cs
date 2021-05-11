using System;
using System.Linq.Expressions;

namespace Kasp.Data.Specification {
	public class AndNotSpecification<T> : CompositeSpecification<T> {
		public AndNotSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right) {
		}

		public override Expression<Func<T, bool>> ToExpression() {
			var rightExpression = Right.ToExpression();

			var bodyNot = Expression.Not(rightExpression.Body);
			var bodyNotExpression = Expression.Lambda<Func<T, bool>>(bodyNot, rightExpression.Parameters);

			return Left.ToExpression().And(bodyNotExpression);
		}
	}
}

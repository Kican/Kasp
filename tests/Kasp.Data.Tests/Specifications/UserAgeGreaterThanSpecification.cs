using System;
using System.Linq.Expressions;
using Kasp.Data.Specification;

namespace Kasp.Data.Test.Specifications {
	public class UserAgeGreaterThanSpecification : Specification<User> {
		private readonly int _minimumAge;

		public UserAgeGreaterThanSpecification(int minimumAge) {
			_minimumAge = minimumAge;
		}

		public override Expression<Func<User, bool>> ToExpression() => user => user.Age >= _minimumAge;
	}
}

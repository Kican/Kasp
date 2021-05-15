using System;
using System.Linq.Expressions;
using Kasp.Data.Specification;

namespace Kasp.Data.Test.Specifications {
	public class UserIdSpecification : Specification<User> {
		private readonly int _userId;

		public UserIdSpecification(int userId) {
			_userId = userId;
		}

		public override Expression<Func<User, bool>> ToExpression() {
			return user => user.Id == _userId;
		}
	}
}

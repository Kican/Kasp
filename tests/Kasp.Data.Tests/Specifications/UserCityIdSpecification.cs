using System;
using System.Linq.Expressions;
using Kasp.Data.Specification;

namespace Kasp.Data.Test.Specifications {
	public class UserCityIdSpecification : Specification<User> {
		private readonly int _cityId;

		public UserCityIdSpecification(int cityId) {
			_cityId = cityId;
		}

		public override Expression<Func<User, bool>> ToExpression() => user => user.CityId == _cityId;
	}
}

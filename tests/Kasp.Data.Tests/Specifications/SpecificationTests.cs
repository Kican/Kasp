using System;
using System.Linq;
using FluentAssertions;
using Kasp.Data.Specification;
using Xunit;

namespace Kasp.Data.Test.Specifications {
	public class SpecificationTests {
		private readonly User[] _users = {
			new() {
				Id = 1,
				Enable = true,
				CreateTime = DateTimeOffset.Now,
				Age = 10,
				CityId = 1,
				Name = "test-1"
			},
			new() {
				Id = 2,
				Enable = true,
				CreateTime = DateTimeOffset.Now,
				Age = 20,
				CityId = 1,
				Name = "test-2"
			},
			new() {
				Id = 3,
				Enable = true,
				CreateTime = DateTimeOffset.Now,
				Age = 14,
				CityId = 1,
				Name = "test-3"
			},
			new() {
				Id = 4,
				Enable = false,
				CreateTime = DateTimeOffset.Now,
				Age = 18,
				CityId = 1,
				Name = "test-4"
			}
		};

		[Fact]
		public void SimpleTest() {
			var result = _users.Where(new UserIdSpecification(1)).First();

			result.Name.Should().Be("test-1");
		}

		[Fact]
		public void AndOperatorTest() {
			var specification = new UserCityIdSpecification(1)
				.And(new UserAgeGreaterThanSpecification(18));

			var result = _users.Where(specification).ToArray();

			result.Should().HaveCount(2);
		}

		[Fact]
		public void OrOperatorTest() {
			var specification = new UserCityIdSpecification(1)
				.Or(new UserAgeGreaterThanSpecification(18));

			var result = _users.Where(specification).ToArray();

			result.Should().HaveCount(4);
		}

		[Fact]
		public void NotOperatorTest() {
			var specification = new UserAgeGreaterThanSpecification(18)
				.Not();

			var result = _users.Where(specification).ToArray();

			result.Should().HaveCount(2);
		}

		[Fact]
		public void AndNotOperatorTest() {
			var specification = new UserCityIdSpecification(1)
				.AndNot(new UserIdSpecification(1));

			var result = _users.Where(specification).ToArray();

			result.Should().HaveCount(3);
		}
	}
}

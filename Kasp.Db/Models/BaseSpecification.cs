using System.Linq;
using Kasp.Db.Extensions;
using Kasp.Db.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Db.Models {
	public abstract class BaseSpecification<T> : ISpecification<T> where T : IModel {
		public IQueryable<T> Query { get; set; }
	}

	public class Test : IModel, IEnable {
		public int Id { get; set; }
		public string Name { get; set; }

		public int ParentId { get; set; }
		public Test Parent { get; set; }
		public bool Enable { get; set; }
	}

	public class TestSpecification : BaseSpecification<Test> {
		public TestSpecification() {
			Query = Query.EnableFilter().Include(x => x.Parent);
		}
	}

	public class TestByUser : TestSpecification {
		public TestByUser(HttpContext httpContext, int userId) {
			if (httpContext.User.IsInRole("admin"))
				Query = Query.Where(x => x.ParentId == userId);
		}
	}
}
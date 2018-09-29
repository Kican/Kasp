using System.Linq;
using Kasp.EF.Extensions;
using Kasp.EF.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Kasp.EF.Models {
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


	public class BaseTestSpecification : BaseSpecification<Test> {
		public BaseTestSpecification() {
			Query = Query.EnableFilter().Include(x => x.Parent);
		}
	}

	public class TestByUser : BaseTestSpecification {
		public TestByUser(HttpContext httpContext, int userId) {
			if (httpContext.User.IsInRole("admin"))
				Query = Query.Where(x => x.ParentId == userId);
		}
	}
}
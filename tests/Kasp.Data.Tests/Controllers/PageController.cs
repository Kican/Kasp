using System;
using System.Linq.Expressions;
using Kasp.Core.Controllers;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Kasp.Data.Specification;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Data.Test.Controllers {
	public class PageController : ApiController {
		private readonly IBaseRepository<Pageable> _repository;

		[HttpGet]
		public ActionResult PageBind([FromQuery] Pageable pageable) {
			var specification = new PageMustHaveIdSpecification().And(new PageCountMustBiggerSpecification(5));

			_repository.ListAsync(specification);

			return Ok(pageable);
		}
	}

	public class Pageable : IPage, IModel {
		public int Page { get; set; }
		public int Count { get; set; }
		public int Id { get; set; }
	}

	public class PageMustHaveIdSpecification : Specification<Pageable> {
		public override Expression<Func<Pageable, bool>> ToExpression() {
			return pageable => pageable.Id > 0;
		}
	}

	public class PageCountMustBiggerSpecification : Specification<Pageable> {
		private readonly int _minCount;

		public PageCountMustBiggerSpecification(int minCount) {
			_minCount = minCount;
		}

		public override Expression<Func<Pageable, bool>> ToExpression() {
			return pageable => pageable.Count >= _minCount;
		}
	}
}

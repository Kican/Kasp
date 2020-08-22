using Kasp.Data;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Kasp.FormBuilder.Services;
using Kasp.ObjectMapper;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Panel.EntityManager.Tests.Controllers {
	[Route("api/entity-manager/test-entity")]
	public class TestEntityManagerController : EntityManagerControllerBase<TestModel, IModelService, TestModel, TestModel, TestModel, FilterBase> {
		public TestEntityManagerController(IModelService repository, IObjectMapper objectMapper, IFormBuilder builder) : base(repository, objectMapper, builder) {
		}
	}

	public class TestModel : IModel {
		public int Id { get; set; }
	}

	public interface IModelService : IFilteredRepositoryBase<TestModel, FilterBase> {
	}
}
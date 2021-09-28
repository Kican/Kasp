namespace Kasp.Panel.EntityManager {
	// public abstract class EntityManagerControllerBase<TModel, TKey, TRepository, TVm, TPartialVm, TEditDto, TFilterDto>
	// 	: CrudApiControllerBase<TModel, TKey, TRepository, TVm, TPartialVm, TEditDto, TFilterDto>
	// 	where TVm : class, IModel<TKey>
	// 	where TFilterDto : FilterBase
	// 	where TEditDto : class
	// 	where TModel : class, IModel<TKey>
	// 	where TKey : IEquatable<TKey>
	// 	where TRepository : IFilteredRepositoryBase<TModel, TKey, TFilterDto>
	// 	where TPartialVm : class, IModel<TKey> {
	// 	private readonly IFormBuilder _builder;
	//
	//
	// 	[HttpGet("$fields/{type}")]
	// 	public async Task<ActionResult<IComponent>> ListFields(string type) {
	// 		if (type == "list")
	// 			return Ok(await _builder.FromModel<TPartialVm>());
	//
	// 		var result = await _builder.FromModel<TEditDto>();
	// 		return Ok(result);
	// 	}
	//
	//
	// 	protected EntityManagerControllerBase(TRepository repository, IObjectMapper objectMapper, IFormBuilder builder) : base(repository, objectMapper) {
	// 		_builder = builder;
	// 	}
	// }
	//
	// public abstract class EntityManagerControllerBase<TModel, TRepository, TVm, TPartialVm, TEditDto, TFilterDto>
	// 	: EntityManagerControllerBase<TModel, int, TRepository, TVm, TPartialVm, TEditDto, TFilterDto>
	// 	where TVm : class, IModel
	// 	where TFilterDto : FilterBase
	// 	where TEditDto : class
	// 	where TModel : class, IModel
	// 	where TRepository : IFilteredRepositoryBase<TModel, int, TFilterDto>
	// 	where TPartialVm : class, IModel {
	// 	protected EntityManagerControllerBase(TRepository repository, IObjectMapper objectMapper, IFormBuilder builder) : base(repository, objectMapper, builder) {
	// 	}
	// }
}

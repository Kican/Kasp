namespace Kasp.Data {
	// [Route("api/[controller]")]
	// public abstract class CrudApiControllerBase<TEntity, TKey, TRepository, TViewDto, TPartialViewDto, TEditDto, TFilterDto> : ApiController
	// 	where TEntity : class, IModel<TKey>
	// 	where TKey : IEquatable<TKey>
	// 	where TRepository : IFilteredRepositoryBase<TEntity, TKey, TFilterDto>
	// 	where TViewDto : class, IModel<TKey>
	// 	where TPartialViewDto : IModel<TKey>
	// 	where TFilterDto : FilterBase {
	//
	// 	protected readonly TRepository Repository;
	// 	protected readonly IObjectMapper _objectMapper;
	//
	// 	protected CrudApiControllerBase(TRepository repository, IObjectMapper objectMapper) {
	// 		Repository = repository;
	// 		_objectMapper = objectMapper;
	// 	}
	//
	// 	[HttpGet]
	// 	public virtual async Task<ActionResult<PagedResult<TPartialViewDto>>> List([FromQuery] TFilterDto filter) {
	// 		return (await Repository.FilterAsync<TPartialViewDto>(filter)).ToPagedResult();
	// 	}
	//
	// 	[HttpGet("{id}")]
	// 	public virtual async Task<ActionResult<TViewDto>> Get(TKey id) {
	// 		return await Repository.GetAsync<TViewDto>(id);
	// 	}
	//
	// 	[HttpPost]
	// 	public virtual async Task<ActionResult<TViewDto>> Create([FromBody] TEditDto model) {
	// 		var item = model.MapTo<TEntity>();
	// 		await Repository.AddAsync(item);
	// 		return CreatedAtAction("Get", new {id = item.Id}, item);
	// 	}
	//
	// 	[HttpPut("{id}")]
	// 	public virtual async Task<ActionResult<TViewDto>> Update(TKey id, [FromBody] TEditDto model) {
	// 		var item = await Repository.GetAsync(id);
	//
	// 		item = _objectMapper.MapTo(model, item);
	// 		await Repository.UpdateAsync(item);
	//
	// 		return item.MapTo<TViewDto>();
	// 	}
	//
	// 	[HttpDelete("{id}")]
	// 	public virtual async Task<IActionResult> Delete(TKey id) {
	// 		await Repository.RemoveAsync(id);
	// 		return NoContent();
	// 	}
	// }
	//
	// public abstract class CrudApiControllerBase<TEntity, TRepository, TViewDto, TPartialViewDto, TEditDto, TFilterDto> :
	// 	CrudApiControllerBase<TEntity, int, TRepository, TViewDto, TPartialViewDto, TEditDto, TFilterDto>
	// 	where TEntity : class, IModel
	// 	where TRepository : IFilteredRepositoryBase<TEntity, TFilterDto>
	// 	where TViewDto : class, IModel
	// 	where TPartialViewDto : IModel
	// 	where TEditDto : IModel
	// 	where TFilterDto : FilterBase {
	// 	protected CrudApiControllerBase(TRepository repository, IObjectMapper objectMapper) : base(repository, objectMapper) {
	// 	}
	// }
	//
	// public abstract class CrudApiControllerBase<TEntity, TRepository, TViewDto, TFilterDto> :
	// 	CrudApiControllerBase<TEntity, int, TRepository, TViewDto, TViewDto, TViewDto, TFilterDto>
	// 	where TEntity : class, IModel
	// 	where TRepository : IFilteredRepositoryBase<TEntity, TFilterDto>
	// 	where TViewDto : class, IModel
	// 	where TFilterDto : FilterBase {
	// 	protected CrudApiControllerBase(TRepository repository, IObjectMapper objectMapper) : base(repository, objectMapper) {
	// 	}
	// }
}

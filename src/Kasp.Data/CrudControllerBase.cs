using System.Threading.Tasks;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Kasp.ObjectMapper;
using Kasp.ObjectMapper.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Data {
	[Route("api/[controller]")]
	public abstract class CrudControllerBase<TRepository, TModel, TViewModel, TInsertModel, TEditModel, TKey> : ControllerBase
		where TRepository : IBaseRepository<TModel, TKey>
		where TInsertModel : IModel<TKey>
		where TViewModel : class, IModel<TKey>
		where TEditModel : IModel<TKey>
		where TModel : class, IModel<TKey> {
		protected CrudControllerBase(TRepository repository, IObjectMapper objectMapper) {
			Repository = repository;
			ObjectMapper = objectMapper;
		}

		protected TRepository Repository { get; }
		protected IObjectMapper ObjectMapper { get; }

		[HttpGet("{id}")]
		public virtual async Task<ActionResult<TViewModel>> Get(TKey id) {
			var item = await Repository.GetAsync<TViewModel>(id);
			if (item == null)
				return NotFound();
			return item;
		}

		[HttpGet]
		public virtual async Task<ActionResult<PagedResult<TViewModel>>> Paged(IPage page) {
			return (await Repository.PagedListAsync<TViewModel>(page.Page, page.Count)).ToPagedResult();
		}

		// todo: must be upsert (update + insert)
		[HttpPut]
		public virtual async Task<ActionResult<TViewModel>> Put([FromBody] TInsertModel model) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var item = ObjectMapper.MapTo<TModel>(model);
			await Repository.AddAsync(item);
			await Repository.SaveAsync();

			return ObjectMapper.MapTo<TViewModel>(item);
		}

		[HttpPatch("{id}")]
		public virtual async Task<ActionResult<TViewModel>> Edit(TKey id, [FromBody] TEditModel model) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var item = await Repository.GetAsync(id);

			if (item == null)
				return NotFound();

			item = ObjectMapper.MapTo(model, item);
			Repository.Update(item);
			await Repository.SaveAsync();
			return item.MapTo<TViewModel>();
		}

		[HttpDelete("{id}")]
		public virtual async Task<IActionResult> Remove(TKey id) {
			await Repository.RemoveAsync(id);
			await Repository.SaveAsync();
			return Ok();
		}
	}

	public abstract class CrudControllerBase<TRepository, TModel, TInsertModel, TViewModel, TEditModel> : CrudControllerBase<TRepository, TModel, TViewModel, TInsertModel, TEditModel, int>
		where TRepository : IBaseRepository<TModel, int>
		where TViewModel : class, IModel
		where TEditModel : IModel
		where TModel : class, IModel
		where TInsertModel : IModel<int> {
		protected CrudControllerBase(TRepository repository, IObjectMapper objectMapper) : base(repository, objectMapper) {
		}
	}

	public abstract class CrudControllerBase<TRepository, TModel, TKey> : CrudControllerBase<TRepository, TModel, TModel, TModel, TModel, TKey>
		where TRepository : IBaseRepository<TModel, TKey>
		where TModel : class, IModel<TKey> {
		protected CrudControllerBase(TRepository repository, IObjectMapper objectMapper) : base(repository, objectMapper) {
		}
	}

	public abstract class CrudControllerBase<TRepository, TModel> : CrudControllerBase<TRepository, TModel, TModel, TModel, TModel>
		where TRepository : IBaseRepository<TModel, int>
		where TModel : class, IModel {
		protected CrudControllerBase(TRepository repository, IObjectMapper objectMapper) : base(repository, objectMapper) {
		}
	}
}
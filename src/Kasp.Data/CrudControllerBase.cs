using System;
using System.Threading.Tasks;
using Kasp.Data.Models;
using Kasp.Data.Models.Helpers;
using Kasp.ObjectMapper;
using Kasp.ObjectMapper.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Data {
	[Route("api/[controller]")]
	public abstract class CrudControllerBase<TRepository, TModel, TViewModel, TPartialVm, TInsertModel, TEditModel, TKey> : ControllerBase
		where TRepository : IBaseRepository<TModel, TKey>
		where TInsertModel : IModel<TKey>
		where TKey :  IEquatable<TKey>
		where TViewModel : class, IModel<TKey>
		where TEditModel : IModel<TKey>
		where TPartialVm : class, IModel<TKey>
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
		public virtual async Task<ActionResult<PagedResult<TPartialVm>>> Paged(IPage page) {
			return (await Repository.PagedListAsync<TPartialVm>(page.Page, page.Count)).ToPagedResult();
		}

		// todo: must be upsert (update + insert)
		[HttpPut]
		public virtual async Task<ActionResult<TViewModel>> Put([FromBody] TInsertModel model) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			TModel item;
			if (model.Id == null || model.Id.Equals(0)) {
				item = ObjectMapper.MapTo<TModel>(model);
				await Repository.AddAsync(item);
			} else {
				item = await Repository.GetAsync(model.Id);
				if (item == null) {
					ModelState.AddModelError("", "item-not-found");
					return BadRequest(ModelState);
				}

				item = ObjectMapper.MapTo(model, item);
				Repository.Update(item);
			}


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

	public abstract class
		CrudControllerBase<TRepository, TModel, TViewModel, TPartialVm, TInsertModel, TEditModel> : CrudControllerBase<TRepository, TModel, TViewModel, TPartialVm, TInsertModel, TEditModel, int>
		where TRepository : IBaseRepository<TModel, int>
		where TViewModel : class, IModel
		where TEditModel : IModel
		where TModel : class, IModel
		where TInsertModel : class, IModel<int>
		where TPartialVm : class, IModel<int> {
		protected CrudControllerBase(TRepository repository, IObjectMapper objectMapper) : base(repository, objectMapper) {
		}
	}

	public abstract class CrudControllerBase<TRepository, TViewModel, TModel, TInsertModel, TEditModel> : CrudControllerBase<TRepository, TModel, TViewModel, TViewModel, TInsertModel, TEditModel, int>
		where TRepository : IBaseRepository<TModel, int>
		where TViewModel : class, IModel
		where TEditModel : IModel
		where TModel : class, IModel
		where TInsertModel : IModel<int> {
		protected CrudControllerBase(TRepository repository, IObjectMapper objectMapper) : base(repository, objectMapper) {
		}
	}
}
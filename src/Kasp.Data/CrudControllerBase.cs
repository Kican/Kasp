using System;
using System.Threading.Tasks;
using AutoMapper;
using Kasp.Core.Controllers;
using Kasp.Data.Models.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Data {
	public abstract class CrudControllerBase<TRepository, TModel, TViewModel, TInsertModel, TEditModel, TKey> : ApiController
		where TRepository : IBaseRepository<TModel, TKey>
		where TViewModel : IModel<TKey>
		where TEditModel : IModel<TKey>
		where TModel : class, IModel<TKey> {
		protected CrudControllerBase(TRepository repository) {
			Repository = repository;
		}

		protected TRepository Repository { get; }
		protected IMapper Mapper { get; }

		[HttpGet]
		public async Task<ActionResult<TViewModel>> Get(TKey id) {
			var item = await Repository.GetAsync<TViewModel>(id);

			if (item == null)
				return NotFound();
			return item;
		}

		[HttpPost]
		public async Task<ActionResult<TViewModel>> Create(TInsertModel model) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var item = Mapper.Map<TModel>(model);
			await Repository.AddAsync(item);
			await Repository.SaveAsync();

			return Mapper.Map<TViewModel>(item);
		}

		[HttpDelete]
		public async Task<IActionResult> Remove(TKey id) {
			await Repository.RemoveAsync(id);
			await Repository.SaveAsync();
			return Ok();
		}
	}

	public abstract class CrudControllerBase<TRepository, TModel, TInsertModel, TViewModel, TEditModel> : CrudControllerBase<TRepository, TModel, TViewModel, TInsertModel, TEditModel, int>
		where TRepository : IBaseRepository<TModel, int>
		where TViewModel : IModel
		where TEditModel : IModel
		where TModel : class, IModel {
		protected CrudControllerBase(TRepository repository) : base(repository) {
		}
	}

	public abstract class CrudControllerBase<TRepository, TModel, TKey> : CrudControllerBase<TRepository, TModel, TModel, TModel, TModel, TKey>
		where TRepository : IBaseRepository<TModel, TKey>
		where TModel : class, IModel<TKey> {
		protected CrudControllerBase(TRepository repository) : base(repository) {
		}
	}

	public abstract class CrudControllerBase<TRepository, TModel> : CrudControllerBase<TRepository, TModel, TModel, TModel, TModel>
		where TRepository : IBaseRepository<TModel, int>
		where TModel : class, IModel {
		protected CrudControllerBase(TRepository repository) : base(repository) {
		}
	}
}
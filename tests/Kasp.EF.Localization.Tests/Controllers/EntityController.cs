using System.Linq;
using System.Threading.Tasks;
using Kasp.Core.Controllers;
using Kasp.EF.Localization.Data.Repositories;
using Kasp.EF.Localization.Tests.Data;
using Kasp.EF.Localization.Tests.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.EF.Localization.Tests.Controllers {
	public class EntityController : ApiController {
		public EntityController(PostRepository postRepository, ILangRepository langRepository) {
			PostRepository = postRepository;
			LangRepository = langRepository;
		}

		private PostRepository PostRepository { get; }
		private ILangRepository LangRepository { get; }

		[HttpGet]
		public async Task<ActionResult<string[]>> LangsInDb() {
			var items = await LangRepository.ListAsync();
			return items.Select(x => x.Code).ToArray();
		}

		[HttpGet]
		public async Task<ActionResult<Post>> Get(int id) {
			var item = await PostRepository.GetAsync(x => x.Id == id);
			if (item == null) return NotFound();
			return item;
		}
	}
}
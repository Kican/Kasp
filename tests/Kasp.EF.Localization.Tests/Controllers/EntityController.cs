using System.Linq;
using System.Threading.Tasks;
using Kasp.Core.Controllers;
using Kasp.EF.Localization.Data.Repositories;
using Kasp.EF.Localization.Tests.Data;
using Kasp.EF.Localization.Tests.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.EF.Localization.Tests.Controllers {
	public class EntityController : ApiController {
		public EntityController(PostRepository postRepository) {
			PostRepository = postRepository;
		}

		private PostRepository PostRepository { get; }

		[HttpGet]
		public async Task<ActionResult<Post[]>> List() {
			var item = await PostRepository.ListFilteredAsync();
			return item.ToArray();
		}
	}
}
using System.Linq;
using System.Threading.Tasks;
using Kasp.Core.Controllers;
using Kasp.Localization.EF.Tests.Data;
using Kasp.Localization.EF.Tests.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Localization.EF.Tests.Controllers {
	public class EntityController : ApiController {
		public EntityController(PostRepository postRepository) {
			PostRepository = postRepository;
		}

		private PostRepository PostRepository { get; }

		[HttpGet]
		public async Task<ActionResult<Post[]>> List() {
			var item = await PostRepository.ListAsync();
			return item.ToArray();
		}
	}
}
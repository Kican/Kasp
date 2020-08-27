using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Panel.Options {
	public abstract class PanelOptionsControllerBase : ControllerBase {
		[HttpGet]
		public async Task<ActionResult<OptionData[]>> List() {
		}

		[HttpGet("$form/{name}")]
		public async Task<ActionResult> Form(string name) {
			
		}
		
		[HttpPut("{name}")]
		public async Task<ActionResult> Update(string name) {
			
		}
	}

	public class OptionData {
		public string Title { get; set; }
		public string Name { get; set; }
	}
}
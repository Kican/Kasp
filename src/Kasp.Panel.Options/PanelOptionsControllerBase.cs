using System;
using System.Linq;
using System.Threading.Tasks;
using Kasp.FormBuilder.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kasp.Panel.Options {
	public abstract class PanelOptionsControllerBase : ControllerBase {
		private readonly IOptions<PanelOptions> _options;
		private readonly IFormBuilder _formBuilder;
		private readonly IWebHostEnvironment _environment;
		private readonly string _file = "appsettings.json";

		protected PanelOptionsControllerBase(IOptions<PanelOptions> options, IFormBuilder formBuilder, IWebHostEnvironment environment) {
			_options = options;
			_formBuilder = formBuilder;
			_environment = environment;
		}

		[HttpGet]
		public ActionResult<OptionData[]> List() {
			return _options.Value.Options.Select(x => new OptionData {Name = x.Name, Title = x.Title}).ToArray();
		}

		[HttpGet("$form/{name}")]
		public async Task<ActionResult> Form(string name) {
			var optionType = _options.Value.Options.FirstOrDefault(x => x.Name == name.ToLower());

			if (optionType == null)
				throw new Exception("option not found");

			return Ok(await _formBuilder.FromModel(optionType.Type));
		}
		
		[HttpGet("{name}")]
		public IActionResult Get(string name) {
			var optionType = _options.Value.Options.FirstOrDefault(x => x.Name == name.ToLower());

			if (optionType == null)
				throw new Exception("option not found");

			return Ok((HttpContext.RequestServices.GetService(typeof(IOptionsSnapshot<>).MakeGenericType(optionType.Type)) as dynamic).Value);
		}

		[HttpPut("{name}")]
		public async Task<ActionResult> Update(string name, [FromBody] JObject data) {
			var optionType = _options.Value.Options.FirstOrDefault(x => x.Name == name.ToLower());

			if (optionType == null)
				throw new Exception("option not found");

			var physicalPath = _environment.ContentRootFileProvider.GetFileInfo(_file).PhysicalPath;
			var jObject = JsonConvert.DeserializeObject<JObject>(await System.IO.File.ReadAllTextAsync(physicalPath));

			if (jObject["app"] == null)
				jObject.Add("app", new JObject());

			jObject["app"][optionType.Name] = JObject.Parse(JsonConvert.SerializeObject(data));

			await System.IO.File.WriteAllTextAsync(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));

			return Ok();
		}
	}

	public class OptionData {
		public string Title { get; set; }
		public string Name { get; set; }
	}
}
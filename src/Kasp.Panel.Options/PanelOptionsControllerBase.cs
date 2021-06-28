using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Kasp.FormBuilder.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Kasp.Panel.Options {
	public abstract class PanelOptionsControllerBase : ControllerBase {
		private readonly IOptions<PanelOptions> _options;
		private readonly IFormBuilder _formBuilder;
		private readonly IWebHostEnvironment _environment;
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

		[HttpPatch("{name}"), HttpPost("{name}")]
		public async Task<ActionResult> Update(string name, [FromBody] JsonElement data) {
			var optionType = _options.Value.Options.FirstOrDefault(x => x.Name == name.ToLower());

			if (optionType == null)
				throw new Exception("option not found");


			if (!TryGetAppSettingPath(out var physicalPath, _environment.EnvironmentName))
				TryGetAppSettingPath(out physicalPath);

			if (string.IsNullOrEmpty(physicalPath))
				throw new Exception("config-file-not-found");


			var newConfig = JsonSerializer.Deserialize(data.ToString() ?? string.Empty, optionType.Type, new JsonSerializerOptions(JsonSerializerDefaults.Web));

			var configContent = await System.IO.File.ReadAllTextAsync(physicalPath);

			var jObject = JsonConvert.DeserializeObject<JObject>(configContent);

			if (jObject["app"] == null)
				jObject.Add("app", new JObject());

			var dataSerialize = JsonConvert.SerializeObject(newConfig);
			jObject["app"][optionType.Name] = JObject.Parse(dataSerialize);

			await System.IO.File.WriteAllTextAsync(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));

			return RedirectToAction("Get", new {name});
		}

		[NonAction]
		public bool TryGetAppSettingPath(out string path, string environment = null) {
			var fileName = "appsettings";

			if (!string.IsNullOrEmpty(environment))
				fileName += $".{environment}";

			fileName += ".json";

			path = _environment.ContentRootFileProvider.GetFileInfo(fileName).PhysicalPath;

			return System.IO.File.Exists(path);
		}
	}

	public class OptionData {
		public string Title { get; set; }
		public string Name { get; set; }
	}
}

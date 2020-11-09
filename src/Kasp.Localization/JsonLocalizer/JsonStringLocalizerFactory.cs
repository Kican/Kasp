using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Kasp.Localization.JsonLocalizer {
	public class JsonStringLocalizerFactory : IStringLocalizerFactory {
		readonly IWebHostEnvironment _env;
		readonly IMemoryCache _memCache;
		readonly IOptions<JsonLocalizationOptions> _localizationOptions;

		readonly string _resourcesRelativePath;

		public JsonStringLocalizerFactory(IWebHostEnvironment env, IMemoryCache memCache) {
			_env = env;
			_memCache = memCache;
		}

		public JsonStringLocalizerFactory(IWebHostEnvironment env, IMemoryCache memCache, IOptions<JsonLocalizationOptions> localizationOptions) {
			if (localizationOptions == null)
				throw new ArgumentNullException(nameof(localizationOptions));


			_env = env;
			_memCache = memCache;
			_localizationOptions = localizationOptions;
			_resourcesRelativePath = _localizationOptions.Value.ResourcesPath ?? String.Empty;
		}


		public IStringLocalizer Create(Type resourceSource) {
			return new JsonStringLocalizer(_env, _memCache, _resourcesRelativePath, _localizationOptions);
		}

		public IStringLocalizer Create(string baseName, string location) {
			return new JsonStringLocalizer(_env, _memCache, _resourcesRelativePath, _localizationOptions);
		}
	}
}

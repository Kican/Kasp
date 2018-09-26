using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kasp.Localization.JsonLocalizer {
	internal abstract class JsonStringLocalizerBase {
		protected List<JsonLocalizationFormat> Localization = new List<JsonLocalizationFormat>();
		protected readonly IHostingEnvironment Env;
		protected readonly IMemoryCache MemCache;
		protected readonly IOptions<JsonLocalizationOptions> LocalizationOptions;
		protected readonly string ResourcesRelativePath;
		protected readonly TimeSpan MemCacheDuration;
		protected const string CacheKey = "JsonLocalizationBlob";
		protected const string FileName = "localize.json";

		protected JsonStringLocalizerBase(IHostingEnvironment env, IMemoryCache memCache, string resourcesRelativePath, IOptions<JsonLocalizationOptions> localizationOptions) {
			Env = env;
			MemCache = memCache;
			ResourcesRelativePath = resourcesRelativePath;
			LocalizationOptions = localizationOptions;
			MemCacheDuration = LocalizationOptions.Value.CacheDuration;
			InitJsonStringLocalizer();
		}

		public JsonStringLocalizerBase(IHostingEnvironment env, IMemoryCache memCache, IOptions<JsonLocalizationOptions> localizationOptions) {
			Env = env;
			MemCache = memCache;
			LocalizationOptions = localizationOptions;
			ResourcesRelativePath = LocalizationOptions.Value.ResourcesPath ?? string.Empty;
			MemCacheDuration = LocalizationOptions.Value.CacheDuration;
			InitJsonStringLocalizer();
		}

		void InitJsonStringLocalizer() {
			// Look for cache key.
			if (!MemCache.TryGetValue(CacheKey, out Localization)) {
				LoadItems();
				SetCache();
			}
		}

		void SetCache() {
			var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(MemCacheDuration);

			// Save data in cache.
			MemCache.Set(CacheKey, Localization, cacheEntryOptions);
		}

		void LoadItems() {
			if (Localization == null)
				Localization = new List<JsonLocalizationFormat>();

			var filePath = Path.Combine(GetJsonRelativePath(), FileName);

			if (!File.Exists(filePath))
				File.WriteAllText(filePath, "{}");

			Localization.Clear();
			Localization.AddRange(JsonConvert.DeserializeObject<List<JsonLocalizationFormat>>(File.ReadAllText(filePath)));

			MergeValues();
		}

		public void SaveItems() {
			var filePath = Path.Combine(GetJsonRelativePath(), FileName);

			File.WriteAllText(filePath, JsonConvert.SerializeObject(Localization));

			LoadItems();
			SetCache();
		}

		void MergeValues() {
			var groups = Localization.GroupBy(g => g.Key);

			var tempLocalization = new List<JsonLocalizationFormat>();

			foreach (var group in groups) {
				try {
					var jsonValues = group
						.Select(s => s.Values)
						.SelectMany(dict => dict)
						.ToDictionary(t => t.Key, t => t.Value, StringComparer.OrdinalIgnoreCase);

					tempLocalization.Add(new JsonLocalizationFormat() {
						Key = group.Key,
						Values = jsonValues
					});
				}
				catch (Exception e) {
					throw new ArgumentException($"{group.Key} could not contains two translation for the same language code", e);
				}
			}

			Localization = tempLocalization;
		}

		string GetJsonRelativePath() {
			return !string.IsNullOrEmpty(ResourcesRelativePath) ? $"{GetBuildPath()}/{ResourcesRelativePath}/" : $"{Env.ContentRootPath}/Resources/";
		}

		string GetBuildPath() {
			return AppContext.BaseDirectory;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kasp.Core.Extensions;
using Kasp.FormBuilder.Extensions;
using Kasp.Options;

namespace Kasp.Panel.Options.Builder {
	public class OptionsBuilder : IOptionsBuilder {
		public List<OptionDto> Options { get; set; } = new List<OptionDto>();

		public IOptionsBuilder AddFromAssembly<T>() {
			return AddFromAssembly(typeof(T).Assembly);
		}

		public IOptionsBuilder AddFromAssemblies(IEnumerable<Assembly> assemblies) {
			foreach (var assembly in assemblies) {
				AddFromAssembly(assembly);
			}

			return this;
		}

		public IOptionsBuilder AddFromAssembly(Assembly assembly) {
			var types = assembly.GetTypes()
				.Where(x =>
					!x.IsAbstract &&
					typeof(IKaspOption).IsAssignableFrom(x)
				)
				.ToArray();

			foreach (var type in types) {
				var attribute = type.GetCustomAttribute<OptionInfoAttribute>();

				var item = new OptionDto {
					Name = type.GetFullTypeName().ToLower(), 
					Title = type.GetDisplayName(),
					Type = type
				};

				if (attribute != null) {
					if (!string.IsNullOrEmpty(attribute.Name))
						item.Name = attribute.Name.ToLower();

					if (!string.IsNullOrEmpty(attribute.Title))
						item.Title = attribute.Title;
				}

				if (Options.Any(x => x.Name == item.Name))
					throw new Exception($"multi option with name `{item.Name}` found ...");

				Options.Add(item);
			}

			return this;
		}
	}
}
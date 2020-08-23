using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kasp.Core.Extensions;
using Kasp.FormBuilder.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Panel.EntityManager.Builder {
	public class EntityManagerBuilder : IEntityManagerBuilder {
		public readonly List<EntityManagerInfo> _managers = new List<EntityManagerInfo>();

		public IEntityManagerBuilder AddFromAssembly<T>() {
			return AddFromAssembly(typeof(T).Assembly);
		}

		public IEntityManagerBuilder AddFromAssemblies(IEnumerable<Assembly> assemblies) {
			foreach (var assembly in assemblies) {
				AddFromAssembly(assembly);
			}

			return this;
		}

		public IEntityManagerBuilder AddFromAssembly(Assembly assembly) {
			var entityManagerType = typeof(EntityManagerControllerBase<,,,,,,>);
			var types = assembly.GetTypes()
				.Where(x => !x.IsAbstract && entityManagerType.IsSubclassOfRawGeneric(x))
				.ToArray();

			foreach (var type in types) {
				var routes = type.GetCustomAttributes<RouteAttribute>(true).ToArray();

				if (!routes.Any())
					throw new Exception($"controller {type.FullName} has not attribute `Route`, its required");

				var path = routes.First().Template.Replace("[controller]", type.Name.Replace("Controller", "", StringComparison.OrdinalIgnoreCase)).ToLower();

				_managers.Add(new EntityManagerInfo {Title = type.GetDisplayName(), Url = path});
			}

			return this;
		}
	}
}
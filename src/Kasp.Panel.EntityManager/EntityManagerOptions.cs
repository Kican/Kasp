using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Kasp.FormBuilder.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Panel.EntityManager {
	public class EntityManagerOptions {
		public List<EntityManagerInfo> Managers { get; set; } = new List<EntityManagerInfo>();

		public EntityManagerOptions AddFromAssembly<T>() {
			return AddFromAssembly(typeof(T).Assembly);
		}

		public EntityManagerOptions AddFromAssemblies(Assembly[] assemblies) {
			foreach (var assembly in assemblies) {
				AddFromAssembly(assembly);
			}

			return this;
		}

		public EntityManagerOptions AddFromAssembly(Assembly assembly) {
			var entityManagerType = typeof(EntityManagerControllerBase<,,,,,,>);
			var types = assembly.GetTypes()
				.Where(x => !x.IsAbstract && x.GetCustomAttribute<NotMappedAttribute>() == null && entityManagerType.IsAssignableFrom(x))
				.ToArray();

			foreach (var type in types) {
				var route = type.GetCustomAttribute<RouteAttribute>(true);

				Managers.Add(new EntityManagerInfo {Title = type.GetDisplayName(), Url = route.Template});
			}

			return this;
		}
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Kasp.Core.Extensions;
using Kasp.FormBuilder.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Kasp.Panel.EntityManager.Builder {
	public class EntityManagerBuilder : IEntityManagerBuilder {
		public readonly List<EntityManagerInfo> Managers = new List<EntityManagerInfo>();

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
				.Where(x =>
					!x.IsAbstract &&
					entityManagerType.IsSubclassOfRawGeneric(x)
				)
				.ToArray();

			foreach (var type in types) {
				// CheckControllerGenericParameters(type);

				var infoAttrib = type.GetCustomAttribute<EntityManagerInfoAttribute>();
				if (infoAttrib != null && !infoAttrib.Discoverable) continue;

				Managers.Add(GetControllerInfo(type));
			}

			return this;
		}

		/// <summary>
		/// check generic parameters like `PartialDto` must not contain class
		/// </summary>
		private void CheckControllerGenericParameters(Type type) {
			foreach (var property in type.GetGenericArguments()[4].GetProperties()) {
				if (property.PropertyType.IsClass)
					throw new Exception($"generic parameter `TPartialVm` in controller `{type.Name}` must not contain class");
			}
		}

		private EntityManagerInfo GetControllerInfo(Type type) {
			var info = new EntityManagerInfo {Title = type.GetDisplayName(), Name = type.Name.Replace("Controller", "", StringComparison.OrdinalIgnoreCase).ToLower(), Url = GetControllerRoute(type)};

			var infoAttrib = type.GetCustomAttribute<EntityManagerInfoAttribute>();
			if (infoAttrib != null) {
				if (!string.IsNullOrEmpty(infoAttrib.Title))
					info.Title = infoAttrib.Title;

				if (!string.IsNullOrEmpty(infoAttrib.Name))
					info.Name = infoAttrib.Name;


				info.Class = infoAttrib.Class;
				info.Icon = infoAttrib.Icon;
			}

			return info;
		}

		private string GetControllerRoute(Type type) {
			var routes = type.GetCustomAttributes<RouteAttribute>(true).ToArray();

			if (!routes.Any())
				throw new Exception($"controller {type.FullName} has not attribute `Route`, its required");

			return routes.First().Template.Replace("[controller]", type.Name.Replace("Controller", "", StringComparison.OrdinalIgnoreCase)).ToLower();
		}
	}
}
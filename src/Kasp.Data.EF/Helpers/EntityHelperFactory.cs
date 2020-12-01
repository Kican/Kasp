using System;
using System.Collections.Generic;
using System.Linq;
using Kasp.Data.Models.Helpers;

namespace Kasp.Data.EF.Helpers {
	public class EntityHelperFactory {
		private static Dictionary<Type, List<IEntityHelper>> Helpers { get; set; } = new();

		static EntityHelperFactory() {
			Add<ICreateTime, CreateTimeEntityHelper>();
			Add<IUpdateTime, UpdateTimeEntityHelper>();
//			Add<IEnable, EnableEntityHelper>();
//			Add<IPublishTime, PublishEntityHelper>();
		}

		public static void Add<T, TEntityHelper>() where TEntityHelper : EntityHelper<T> {
			if (Helpers.ContainsKey(typeof(T))) {
				Helpers[typeof(T)].Add(Activator.CreateInstance<TEntityHelper>());
			} else {
				Helpers.Add(typeof(T), new List<IEntityHelper>());
				Helpers[typeof(T)].Add(Activator.CreateInstance<TEntityHelper>());
			}
		}

		public static List<IEntityHelper> GetHelpers() {
			return Helpers.SelectMany(x => x.Value).ToList();
		}

		public static List<IEntityHelper> GetQueryFilter<T>() {
			return Helpers.Where(x => x.Key.IsAssignableFrom(typeof(T))).SelectMany(x => x.Value).ToList();
		}

		public static List<IEntityHelper> GetQueryFilter(Type type) {
			return Helpers.Where(x => x.Key.IsAssignableFrom(type)).SelectMany(x => x.Value).ToList();
		}
	}
}

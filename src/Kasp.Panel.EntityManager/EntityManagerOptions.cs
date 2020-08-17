using System.Collections.Generic;
using System.Reflection;

namespace Kasp.Panel.EntityManager {
	public class EntityManagerOptions {
		public List<EntityManagerInfo> Managers { get; set; } = new List<EntityManagerInfo>();

		public EntityManagerOptions AddFromAssembly<T>() {
			return this;
		}

		public EntityManagerOptions AddFromAssemblies(Assembly[] assemblies) {
			return this;
		}

		public EntityManagerOptions AddFromAssembly(Assembly assembly) {
			return this;
		}
	}
}
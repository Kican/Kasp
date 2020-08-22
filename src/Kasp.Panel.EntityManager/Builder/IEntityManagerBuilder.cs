using System.Collections.Generic;
using System.Reflection;

namespace Kasp.Panel.EntityManager.Builder {
	public interface IEntityManagerBuilder {
		IEntityManagerBuilder AddFromAssembly<T>();
		IEntityManagerBuilder AddFromAssemblies(IEnumerable<Assembly> assemblies);
		IEntityManagerBuilder AddFromAssembly(Assembly assembly);
	}
}
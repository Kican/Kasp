using System.Collections.Generic;
using System.Reflection;

namespace Kasp.Panel.Options.Builder {
	public interface IOptionsBuilder {
		IOptionsBuilder AddFromAssembly<T>();
		IOptionsBuilder AddFromAssemblies(IEnumerable<Assembly> assemblies);
		IOptionsBuilder AddFromAssembly(Assembly assembly);
	}
}
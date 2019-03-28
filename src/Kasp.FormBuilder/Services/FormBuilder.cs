using System;
using System.Reflection;
using System.Threading.Tasks;
using Kasp.FormBuilder.Components;
using Kasp.FormBuilder.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.FormBuilder.Services {
	public class FormBuilder : IFormBuilder {
		public FormBuilder(FormBuilderOptions formBuilderOptions, IServiceProvider serviceProvider) {
			FormBuilderOptions = formBuilderOptions;
			ServiceProvider = serviceProvider;
		}

		private FormBuilderOptions FormBuilderOptions { get; }
		private IServiceProvider ServiceProvider { get; }

		public async Task<IComponent> FromModel<TModel>() where TModel : class => await FromModel(typeof(TModel));

		public async Task<IComponent> FromModel(Type type) {
			var resolverType = FormBuilderOptions.ComponentHandlers.FindHandler(type).GetResolverType();
			var resolver = (IComponentResolver) ServiceProvider.GetService(resolverType);

			return await resolver.ResolveAsync(type);
		}

		public async Task<IComponent> FromProperty(PropertyInfo type) {
			var resolverType = FormBuilderOptions.ComponentHandlers.FindHandler(type).GetResolverType();
			var resolver = (IComponentResolver) ServiceProvider.GetService(resolverType);

			return await resolver.ResolveAsync(type);
		}
	}
}
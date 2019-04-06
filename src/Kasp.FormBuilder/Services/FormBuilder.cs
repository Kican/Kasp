using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;
using Kasp.FormBuilder.Components;
using Kasp.FormBuilder.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.FormBuilder.Services {
	public class FormBuilder : IFormBuilder {
		public FormBuilder(FormBuilderOptions formBuilderOptions, IServiceProvider serviceProvider, IEnumerable<IValidatorResolver> validatorResolvers) {
			FormBuilderOptions = formBuilderOptions;
			ServiceProvider = serviceProvider;
			ValidatorResolvers = validatorResolvers;
		}

		private FormBuilderOptions FormBuilderOptions { get; }
		private IServiceProvider ServiceProvider { get; }
		private IEnumerable<IValidatorResolver> ValidatorResolvers { get; }

		public async Task<IComponent> FromModel<TModel>() where TModel : class => await FromModel(typeof(TModel));

		public async Task<IComponent> FromModel(Type type) {
			var options = GetOptions(type);

			var resolverType = FormBuilderOptions.ComponentHandlers.FindHandler(options).GetResolverType();
			var resolver = (IComponentResolver) ServiceProvider.GetService(resolverType);

			return await resolver.ResolveAsync(options);
		}

		public async Task<IComponent> FromProperty(PropertyInfo type) {
			var options = GetOptions(type);

			var resolverType = FormBuilderOptions.ComponentHandlers.FindHandler(options).GetResolverType();
			var resolver = (IComponentResolver) ServiceProvider.GetService(resolverType);

			return await resolver.ResolveAsync(options);
		}

		private ComponentOptions GetOptions(Type type) {
			return new ComponentOptions {Type = type, Name = type.Name};
		}

		private ComponentOptions GetOptions(PropertyInfo propertyInfo) {
			var validators = new List<IValidator>();
			
			foreach (var resolver in ValidatorResolvers)
				validators.AddRange(resolver.GetValidators(propertyInfo));

			return new ComponentOptions {Type = propertyInfo.PropertyType, PropertyInfo = propertyInfo, Name = propertyInfo.Name, Validators = validators};
		}
	}
}
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
		public FormBuilder(FormBuilderOptions formBuilderOptions, IServiceProvider serviceProvider) {
			FormBuilderOptions = formBuilderOptions;
			ServiceProvider = serviceProvider;
		}

		private FormBuilderOptions FormBuilderOptions { get; }
		private IServiceProvider ServiceProvider { get; }

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
			var attributeValidators = propertyInfo.GetCustomAttributes<ValidationAttribute>();

			var validators = new List<IValidator>();
			foreach (var validationAttribute in attributeValidators) {
				var validator = FormBuilderOptions.ValidatorCollection.Convert(validationAttribute);
				if (validator != null)
					validators.Add(validator);
			}

			return new ComponentOptions {Type = propertyInfo.PropertyType, PropertyInfo = propertyInfo, Name = propertyInfo.Name, Validators = validators};
		}
	}
}
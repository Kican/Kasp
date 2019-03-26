using System;
using System.Threading.Tasks;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Services {
	public class FormBuilder : IFormBuilder {
		public FormBuilder(FormBuilderOptions formBuilderOptions) {
			FormBuilderOptions = formBuilderOptions;
		}

		private FormBuilderOptions FormBuilderOptions { get; }

		public async Task<IComponent> FromModel<TModel>() where TModel : class => await FromModel(typeof(TModel));

		public async Task<IComponent> FromModel(Type type) {
			return FormBuilderOptions.ComponentHandlers.FindHandler(type).Process();
		}
	}
}
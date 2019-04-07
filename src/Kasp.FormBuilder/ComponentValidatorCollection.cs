using System.Collections.ObjectModel;
using System.Linq;
using Kasp.FormBuilder.Models;
using Kasp.FormBuilder.Validators.MvcAttributeParsers;

namespace Kasp.FormBuilder {
	public class ComponentValidatorCollection : Collection<IValidatorParser> {
		public ComponentValidatorCollection() {
			Add(new RequiredAttributeParser());
			Add(new MaxLengthAttributeParser());
			Add(new StringLengthAttributeParser());
		}

		public IValidator Convert(object @object) {
			var validator = this.FirstOrDefault(x => x.SourceType == @object.GetType());
			return validator?.Process(@object);
		}
	}
}
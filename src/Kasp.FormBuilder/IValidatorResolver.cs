using System.Reflection;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder {
	public interface IValidatorResolver {
		IValidator[] GetValidators(PropertyInfo propertyInfo);
	}
}
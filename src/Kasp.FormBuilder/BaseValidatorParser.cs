using System;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder;

public abstract class BaseValidatorParser<TAttribute, TValidator> : IValidatorParser where TValidator : IValidator where TAttribute : class {
	public abstract TValidator Parse(TAttribute attribute);

	public IValidator Process(object @class) => Parse(@class as TAttribute);
	public Type SourceType => typeof(TAttribute);
}

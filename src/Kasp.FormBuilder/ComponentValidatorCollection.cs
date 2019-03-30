using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Kasp.FormBuilder.Models;
using Kasp.FormBuilder.Validators;

namespace Kasp.FormBuilder {
	public class ComponentValidatorCollection : Collection<IValidatorParser> {
		public ComponentValidatorCollection() {
			Add(new RequiredAttributeParser());
			Add(new MaxLengthAttributeParser());
			Add(new StringLengthAttributeParser());
		}
	}

	public interface IValidatorParser {
		IValidator Process(object @class);
	}

	public abstract class BaseValidatorParser<TAttribute, TValidator> : IValidatorParser where TAttribute : Attribute where TValidator : IValidator {
		public abstract TValidator Parse(TAttribute attribute);

		public IValidator Process(object @class) => Parse(@class as TAttribute);
	}

	public class RequiredAttributeParser : BaseValidatorParser<RequiredAttribute, RequiredValidator> {
		public override RequiredValidator Parse(RequiredAttribute attribute) {
			return new RequiredValidator();
		}
	}

	public class MaxLengthAttributeParser : BaseValidatorParser<MaxLengthAttribute, MaxLengthValidator> {
		public override MaxLengthValidator Parse(MaxLengthAttribute attribute) => new MaxLengthValidator {Length = attribute.Length, Message = attribute.ErrorMessage};
	}

	public class StringLengthAttributeParser : BaseValidatorParser<StringLengthAttribute, RangeLengthValidator> {
		public override RangeLengthValidator Parse(StringLengthAttribute attribute) {
			return new RangeLengthValidator {Max = attribute.MaximumLength, Min = attribute.MinimumLength};
		}
	}
}
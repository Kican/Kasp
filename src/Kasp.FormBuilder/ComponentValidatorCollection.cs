using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Kasp.FormBuilder.Models;
using Kasp.FormBuilder.Validators;

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

	public interface IValidatorParser {
		IValidator Process(object @class);
		Type SourceType { get; }
	}

	public abstract class BaseValidatorParser<TAttribute, TValidator> : IValidatorParser where TValidator : IValidator where TAttribute : class {
		public abstract TValidator Parse(TAttribute attribute);

		public IValidator Process(object @class) => Parse(@class as TAttribute);
		public Type SourceType => typeof(TAttribute);
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
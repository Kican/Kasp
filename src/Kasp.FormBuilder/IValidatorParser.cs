using System;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder; 

public interface IValidatorParser {
	IValidator Process(object @class);
	Type SourceType { get; }
}
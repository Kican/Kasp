using System;
using System.Collections.Generic;
using System.Reflection;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components;

public class ComponentOptions : IComponentValidators {
	public PropertyInfo PropertyInfo { get; set; }
	public Type Type { get; set; }
	public string Name { get; set; }
	public List<IValidator> Validators { get; set; }
}

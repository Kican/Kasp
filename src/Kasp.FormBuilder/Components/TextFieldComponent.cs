using System;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components {
    public class TextFieldComponent : BaseFormComponent, IFormComponentRequired {
        public bool Required { get; set; }

        public override bool IsEntityOwner(Type type) => true;
    }
}
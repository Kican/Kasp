using System;
using System.Collections.Generic;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components {
    public class TextFieldComponent : BaseComponent, IComponentRequired, IComponentEditable, IComponentTitle, IComponentValidators {
        public bool Required { get; set; }
        public bool Editable { get; set; }
        public string Title { get; set; }
        public List<IValidator> Validators { get; set; }

        public override bool IsEntityOwner(Type type) => true;
    }
}
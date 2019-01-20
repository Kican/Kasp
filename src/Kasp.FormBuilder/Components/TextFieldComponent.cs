using System;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components {
    public class TextFieldComponent : BaseComponent, IComponentRequired, IComponentEditable {
        public bool Required { get; set; }
        public bool Editable { get; set; }

        public override bool IsEntityOwner(Type type) => true;
    }
}
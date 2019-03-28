using System.Collections.Generic;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components.Elements {
    public class TextFieldComponent : BaseComponent, IComponentEditable, IComponentTitle, IComponentValidators {
        public bool Editable { get; set; }
        public string Title { get; set; }
        public List<IValidator> Validators { get; set; }
    }
}
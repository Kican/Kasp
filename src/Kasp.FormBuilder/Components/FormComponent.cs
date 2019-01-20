using System;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components {
    public class FormComponent : BaseFormComponent, IFormComponentTitle {
        public string Title { get; set; }

        public override bool IsEntityOwner(Type type) => false;
    }
}
using System;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components {
    public class FormComponent : BaseComponent, IFormComponentTitle {
        public string Title { get; set; }

        public override bool IsEntityOwner(Type type) => false;
    }
}
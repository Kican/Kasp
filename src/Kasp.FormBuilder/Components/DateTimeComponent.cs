using System;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Components {
    public class DateTimeComponent : BaseFormComponent, IFormComponentRequired {
        public bool Required { get; set; }

        public override bool IsEntityOwner(Type type) {
            return type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?) ||
                   type == typeof(DateTime) || type == typeof(DateTime?);
        }
    }
}
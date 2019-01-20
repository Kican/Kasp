using System;

namespace Kasp.FormBuilder.Models {
    public abstract class BaseFormComponent : IFormComponent {
        public string Name { get; set; }
        
        public abstract bool IsEntityOwner(Type type);
    }
}
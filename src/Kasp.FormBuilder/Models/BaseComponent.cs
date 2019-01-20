using System;

namespace Kasp.FormBuilder.Models {
    public abstract class BaseComponent : IComponent {
        public string Name { get; set; }
        
        public abstract bool IsEntityOwner(Type type);
    }
}
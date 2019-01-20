using System;

namespace Kasp.FormBuilder.Models {
    public interface IComponent {
        string Name { get; set; }
        bool IsEntityOwner(Type type);
    }
}
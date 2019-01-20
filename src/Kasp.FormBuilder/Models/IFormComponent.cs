using System;

namespace Kasp.FormBuilder.Models {
    public interface IFormComponent {
        string Name { get; set; }
        bool IsEntityOwner(Type type);
    }
}
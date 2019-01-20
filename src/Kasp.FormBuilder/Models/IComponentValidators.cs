using System.Collections.Generic;

namespace Kasp.FormBuilder.Models {
    public interface IComponentValidators {
        List<IValidator> Validators { get; set; }
    }
}
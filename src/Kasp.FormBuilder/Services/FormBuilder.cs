using System;
using System.Threading.Tasks;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Services {
    public class FormBuilder : IFormBuilder {
        public Task<IFormComponent> FromModel<TModel>() where TModel : class {
            throw new NotImplementedException();
        }

        public Task<IFormComponent> FromModel(Type type) {
            throw new NotImplementedException();
        }
    }
}
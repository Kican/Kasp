using System;
using System.Threading.Tasks;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Services {
    public class FormBuilder : IFormBuilder {
        public Task<IComponent> FromModel<TModel>() where TModel : class {
            throw new NotImplementedException();
        }

        public Task<IComponent> FromModel(Type type) {
            throw new NotImplementedException();
        }
    }
}
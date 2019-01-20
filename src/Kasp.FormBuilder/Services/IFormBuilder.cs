using System;
using System.Threading.Tasks;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Services {
    public interface IFormBuilder {
        Task<IComponent> FromModel<TModel>() where TModel : class;
        Task<IComponent> FromModel(Type type);
    }
}
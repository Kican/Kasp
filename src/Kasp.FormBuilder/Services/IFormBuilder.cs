using System;
using System.Threading.Tasks;
using Kasp.FormBuilder.Models;

namespace Kasp.FormBuilder.Services {
    public interface IFormBuilder {
        Task<IFormComponent> FromModel<TModel>() where TModel : class;
        Task<IFormComponent> FromModel(Type type);
    }
}
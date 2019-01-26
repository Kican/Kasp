using System;
using System.Collections.ObjectModel;
using Kasp.FormBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kasp.FormBuilder.Components {
    public class ComponentCollection : Collection<IComponent> {
        public IComponent Add<TFilterType>() where TFilterType : IComponent {
            return Add(TFilterType);
        }


    }
}
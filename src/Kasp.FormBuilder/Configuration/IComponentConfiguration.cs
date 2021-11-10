using System;
using System.Linq.Expressions;
using Kasp.FormBuilder.Components;

namespace Kasp.FormBuilder.Configuration; 

public interface IComponentConfiguration<TComponent, TEntity> where TComponent : IComponent {
	IComponentConfiguration<TComponent, TEntity> SetName(string name);
	IComponentConfiguration<TComponent, TEntity> SetComponentValue<TValue>(Expression<Func<TComponent, TValue>> expression, TValue value);
}
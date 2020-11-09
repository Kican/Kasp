using System;
using System.Linq.Expressions;
using Kasp.FormBuilder.Components;

namespace Kasp.FormBuilder.Configuration {
	public interface ILayoutConfiguration<TLayout, TEntity> : IComponentConfiguration<TLayout, TEntity> where TLayout : ILayoutComponent {
		ILayoutConfiguration<ILayoutComponent, TEntity> AddComponent<TComponent>(Expression<Func<TEntity, object>> expression, Action<IComponentConfiguration<TComponent, TEntity>> builderAction)
			where TComponent : IComponent;
	}
}
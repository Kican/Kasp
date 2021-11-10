using System;
using Kasp.FormBuilder.Components;

namespace Kasp.FormBuilder.Configuration; 

public interface IConfigureBuilder<TEntity> {
	void WithLayout<TLayout, TConfiguration>(Action<TConfiguration> configureAction) where TLayout : ILayoutComponent where TConfiguration : IComponentConfiguration<TLayout, TEntity>;
}
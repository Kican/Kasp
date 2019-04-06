using Kasp.FormBuilder.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.FormBuilder {
    public class FormBuilderOptions {
	    public FormBuilderOptions(IServiceCollection serviceCollection) {
		    ServiceCollection = serviceCollection;
	    }

	    public IServiceCollection ServiceCollection { get; }
	    
        public ComponentHandlerCollection ComponentHandlers { get; } = new ComponentHandlerCollection();
        public ComponentValidatorCollection ValidatorCollection { get; } = new ComponentValidatorCollection();
    }
}
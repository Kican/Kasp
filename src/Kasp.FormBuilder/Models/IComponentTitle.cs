using Kasp.FormBuilder.Components;

namespace Kasp.FormBuilder.Models; 

public interface IComponentTitle : IComponent {
	string Title { get; set; }
}
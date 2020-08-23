using System.Text.Json.Serialization;

namespace Kasp.FormBuilder.Components.Layouts {
	public class LinearLayoutComponent : BaseLayoutComponent {
		public LinearLayoutOrientation Orientation { get; set; } = LinearLayoutOrientation.Vertical;
	}

	public enum LinearLayoutOrientation {
		Vertical = 0,
		Horizontal = 1
	}
}
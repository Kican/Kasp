using System;

namespace Kasp.Panel.EntityManager {
	[AttributeUsage(AttributeTargets.Class)]
	public class EntityManagerInfoAttribute : Attribute {
		public EntityManagerInfoAttribute(string title) {
			Title = title;
		}

		public string Title { get; }
		public string Name { get; set; }
		public string Icon { get; set; }
		public string Class { get; set; }
		public bool Discoverable { get; set; } = true;
	}
}
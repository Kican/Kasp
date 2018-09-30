using System.ComponentModel.DataAnnotations;
using Kasp.EF.Models.Helpers;

namespace Kasp.EF.Localization.Models {
	public class Lang : IModel, IEnable, IPriority {
		public bool Enable { get; set; }

		public int Id { get; set; }

		[MaxLength(10), Required]
		public string Code { get; set; }

		public int Priority { get; set; }
	}
}
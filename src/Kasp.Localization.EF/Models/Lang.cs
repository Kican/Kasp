using System.ComponentModel.DataAnnotations;
using Kasp.Data.Models.Helpers;

namespace Kasp.Localization.EF.Models {
	public class Lang : IModel<string>, IEnable, IPriority {
		public bool Enable { get; set; }
		public int Priority { get; set; }

		[MaxLength(5), Required]
		public string Id { get; set; }
	}
}
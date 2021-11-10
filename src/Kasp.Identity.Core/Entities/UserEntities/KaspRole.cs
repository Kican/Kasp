using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Kasp.Identity.Core.Entities.UserEntities; 

public class KaspRole<TKey> : IdentityRole<TKey> where TKey : IEquatable<TKey> {
	public KaspRole() {
	}

	public KaspRole(string name) {
		Name = name;
	}

	[MaxLength(300)]
	public string Description { get; set; }

	[MaxLength(100)]
	public string Title { get; set; }
}

public class KaspRole : KaspRole<int> {
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// The status of a <see cref="Disposition"/>.
	/// </summary>
	public enum DispositionStatus
	{
		/// <summary>
		/// Assigned to a user but not verified.
		/// Security rights are granted though.
		/// </summary>
		[Display(ResourceType = typeof(DispositionStatusResources),
			Name = nameof(DispositionStatusResources.Unverified_Name))]
		Unverified,

		/// <summary>
		/// Assigned to a user and verified.
		/// Security rights are granted.
		/// </summary>
		[Display(ResourceType = typeof(DispositionStatusResources),
			Name = nameof(DispositionStatusResources.Verified_Name))]
		Verified,

		/// <summary>
		/// Assigned to a user in the past but inactive today.
		/// Security rights are granted.
		/// </summary>
		[Display(ResourceType = typeof(DispositionStatusResources),
			Name = nameof(DispositionStatusResources.Inactive_Name))]
		Inactive,

		/// <summary>
		/// Assigned to a user in the past but revoked today.
		/// Security rights are NOT granted.
		/// </summary>
		[Display(ResourceType = typeof(DispositionStatusResources),
			Name = nameof(DispositionStatusResources.Revoked_Name))]
		Revoked
	}
}

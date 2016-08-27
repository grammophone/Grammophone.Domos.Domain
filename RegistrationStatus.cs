using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// The status of a user registration.
	/// </summary>
	public enum RegistrationStatus
	{
		/// <summary>
		/// User is registered but not verified.
		/// </summary>
		[Display(ResourceType = typeof(RegistrationStatusResources), Name = "PendingVerification_Name")]
		PendingVerification,

		/// <summary>
		/// The user is both registered and verified.
		/// </summary>
		[Display(ResourceType = typeof(RegistrationStatusResources), Name = "Verified_Name")]
		Verified,

		/// <summary>
		/// User registration has been revoked.
		/// </summary>
		[Display(ResourceType = typeof(RegistrationStatusResources), Name = "Revoked_Name")]
		Revoked
	}
}

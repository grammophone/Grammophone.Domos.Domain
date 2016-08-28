using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// The state of a <see cref="Disposition{U}"/>.
	/// </summary>
	public enum DispositionState
	{
		/// <summary>
		/// Assigned to a user but not verified.
		/// Security rights are granted though.
		/// </summary>
		Unverified,

		/// <summary>
		/// Assigned to a user and verified.
		/// Security rights are granted.
		/// </summary>
		Verified,

		/// <summary>
		/// Assigned to a user in the past but inactive today.
		/// Security rights are granted.
		/// </summary>
		Inactive,

		/// <summary>
		/// Assigned to a user in the past but revoked today.
		/// Security rights are NOT granted.
		/// </summary>
		Revoked
	}
}

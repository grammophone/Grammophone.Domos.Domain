using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Base interface implemented by entities supporting
	/// change tracking.
	/// </summary>
	public interface ITrackingEntity
	{
		/// <summary>
		/// Date when the entity was created, in UTC.
		/// Set by the system.
		/// Once set, cannot be changed.
		/// </summary>
		DateTime CreationDate { get; set; }

		/// <summary>
		/// Date of the last modification of the entity, in UTC.
		/// Set by the system.
		/// </summary>
		DateTime LastModificationDate { get; set; }

		/// <summary>
		/// ID of the user who created the entity.
		/// Set by the system.
		/// Once set, cannot be changed.
		/// </summary>
		long CreatorUserID { get; set; }

		/// <summary>
		/// ID of the user who modified the entity last.
		/// It will be set by the system.
		/// </summary>
		long LastModifierUserID { get; set; }
	}

	/// <summary>
	/// Implemented by entities supporting change tracking.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	public interface ITrackingEntity<U> : ITrackingEntity
		where U : User
	{
		/// <summary>
		/// The user who created the entity.
		/// Set by the system.
		/// Once set, cannot be changed.
		/// </summary>
		U CreatorUser { get; set; }

		/// <summary>
		/// The user who modified the entity last.
		/// Set by the system.
		/// </summary>
		U LastModifierUser { get; set; }
	}
}

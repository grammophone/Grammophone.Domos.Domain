using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base interface implemented by entities supporting user ownership
	/// and change tracking.
	/// </summary>
	public interface IUserTrackingEntity : ITrackingEntity
	{
		/// <summary>
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed.
		/// </summary>
		long OwnerUserID { get; set; }
	}

	/// <summary>
	/// Implemented by entities supporting user ownership and change tracking.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	public interface IUserTrackingEntity<U> : IUserTrackingEntity, ITrackingEntity<U>
		where U : User
	{
		/// <summary>
		/// The owner of the entity.
		/// Once set, cannot be changed.
		/// </summary>
		U OwnerUser { get; set; }
	}
}

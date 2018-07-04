using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Contract for entities supporting user ownership
	/// and change tracking.
	/// </summary>
	public interface IUserTrackingEntity : ITrackingEntity
	{
		/// <summary>
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed.
		/// </summary>
		long OwningUserID { get; set; }
	}

	/// <summary>
	/// Strong-type contract for entities supporting user ownership and change tracking.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	public interface IUserTrackingEntity<U> : IUserTrackingEntity, ITrackingEntity<U>, IUpdatableOwnerEntity<U>
		where U : User
	{
		/// <summary>
		/// The owner of the entity.
		/// Once set, cannot be changed.
		/// </summary>
		U OwningUser { get; set; }
	}
}

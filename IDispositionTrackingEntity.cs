using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Contract for entities supporting user disposition ownership and change tracking.
	/// These are entities that inherently belong to a <see cref="SegregationID"/>.
	/// </summary>
	public interface IDispositionTrackingEntity<U> : IUserTrackingEntity<U>, ISegregationTrackingEntity
		where U : User
	{
		/// <summary>
		/// The ID of the disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		long OwnerDispositionID { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base class for entities supporting user ownership and change tracking
	/// as well as belonging to a segregation.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class UserSegregationTrackingEntity<U> : UserTrackingEntity<U>, ISegregationTrackingEntity
		where U : User
	{
		#region Private fields

		private long segregationID;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The ID of the segregation where this entity belongs.
		/// Once set, cannot be changed.
		/// </summary>
		public virtual long SegregationID
		{
			get
			{
				return segregationID;
			}
			set
			{
				if (segregationID != value)
				{
					if (segregationID != 0L) throw new DomainAccessDeniedException("The segregation cannot be changed.", this);

					segregationID = value;
				}
			}
		}

		#endregion
	}
}

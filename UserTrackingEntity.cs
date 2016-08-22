using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base class for entities supporting user ownership and change tracking.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public class UserTrackingEntity<U> : TrackingEntity<U>, IUserTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private long ownerUserID;

		private U ownerUser;

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual long OwnerUserID
		{
			get
			{
				return ownerUserID;
			}
			set
			{
				if (ownerUserID != value)
				{
					if (ownerUserID != 0L)
						throw new DomainAccessDeniedException("The owner of the entity cannot be changed.", this);

					ownerUserID = value;
				}
			}
		}

		/// <summary>
		/// The owner of the entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual U OwnerUser
		{
			get
			{
				return ownerUser;
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				if (ownerUser != value)
				{
					if (ownerUser != null)
						throw new DomainAccessDeniedException("The owner of the entity cannot be changed.", this);

					ownerUser = value;
				}
			}
		}

		#endregion
	}
}

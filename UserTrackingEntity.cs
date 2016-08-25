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

		private UserTrackingTrait<U> userTrackingTrait;

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual long OwningUserID
		{
			get
			{
				return userTrackingTrait.OwningUserID;
			}
			set
			{
				userTrackingTrait.OwningUserID = value;
			}
		}

		/// <summary>
		/// The owner of the entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual U OwningUser
		{
			get
			{
				return userTrackingTrait.OwningUser;
			}
			set
			{
				userTrackingTrait.OwningUser = value;
			}
		}

		#endregion
	}
}

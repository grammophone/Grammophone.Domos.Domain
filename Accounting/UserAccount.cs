using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// Account which belongs to a user.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public class UserAccount<U> : Account<U>, IUserTrackingEntity<U>
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
		public virtual long OwnerUserID
		{
			get
			{
				return userTrackingTrait.OwnerUserID;
			}
			set
			{
				userTrackingTrait.OwnerUserID = value;
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
				return userTrackingTrait.OwnerUser;
			}
			set
			{
				userTrackingTrait.OwnerUser = value;
			}
		}

		#endregion
	}
}

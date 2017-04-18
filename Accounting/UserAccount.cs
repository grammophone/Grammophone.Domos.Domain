using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Account owned by a user.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class UserAccount<U> : TrackingAccount<U>, IUserTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private UserTrackingTrait<U> userTrackingTrait;

		#endregion

		#region IUserTrackingEntity<U> implementation

		/// <summary>
		/// The owner of the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public U OwningUser
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

		/// <summary>
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public long OwningUserID
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
		/// Test whether a user is the owner of the account.
		/// </summary>
		/// <param name="userID">The ID of the user.</param>
		public bool IsOwnedBy(long userID)
		{
			return userID == this.OwningUserID;
		}

		/// <summary>
		/// Test whether a user is the owner of the account.
		/// </summary>
		/// <param name="user">The user.</param>
		public bool IsOwnedBy(U user)
		{
			if (user == null) throw new ArgumentNullException(nameof(user));

			return user.ID == this.OwningUserID;
		}

		#endregion
	}
}

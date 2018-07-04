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
		public bool IsOwnedBy(long userID) => userTrackingTrait.IsOwnedBy(userID);

		/// <summary>
		/// Test whether a user is the owner of the account.
		/// </summary>
		/// <param name="user">The user.</param>
		public bool IsOwnedBy(U user) => userTrackingTrait.IsOwnedBy(user);

		/// <summary>
		/// Returns true when the account has an owner, false otherwise.
		/// </summary>
		public bool HasOwners() => userTrackingTrait.HasOwners();

		/// <summary>
		/// Set the <see cref="OwningUser"/> of the account. Any
		/// previous owner will be replaced.
		/// </summary>
		/// <param name="user">The user to own the account.</param>
		/// <returns>Always returns true.</returns>
		public bool AddOwner(U user) => userTrackingTrait.AddOwner(user);

		#endregion
	}
}

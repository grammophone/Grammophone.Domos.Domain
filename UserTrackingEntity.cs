using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Base class for entities supporting user ownership and change tracking.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class UserTrackingEntity<U> : TrackingEntity<U>, IUserTrackingEntity<U>, IUpdatableOwnerEntity<U>
		where U : User
	{
		#region Private fields

		private UserTrackingTrait<U> userTrackingTrait;

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed, except via method <see cref="AddOwner(U)"/>.
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
		/// Once set, cannot be changed, except via method <see cref="AddOwner(U)"/>.
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

		#region Public methods

		/// <summary>
		/// Test whether a user is the owner of the entity.
		/// </summary>
		/// <param name="userID">The ID of the user.</param>
		public bool IsOwnedBy(long userID) => userTrackingTrait.IsOwnedBy(userID);

		/// <summary>
		/// Test whether a user is the owner of the entity.
		/// </summary>
		/// <param name="user">The user.</param>
		public bool IsOwnedBy(U user) => userTrackingTrait.IsOwnedBy(user);

		/// <summary>
		/// Returns true when the entity has an owner, false otherwise.
		/// </summary>
		public bool HasOwners() => userTrackingTrait.HasOwners();

		/// <summary>
		/// Set the owner for the entity. Any
		/// previous owner will be replaced.
		/// </summary>
		/// <param name="user">The user to own the entity.</param>
		/// <returns>Always returns true.</returns>
		public bool AddOwner(U user) => userTrackingTrait.AddOwner(user);

		#endregion
	}
}

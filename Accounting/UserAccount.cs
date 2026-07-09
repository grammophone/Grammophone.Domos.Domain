using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

		private long owningUserID;

		private U owningUser;

		#endregion

		#region IUserTrackingEntity<U> implementation

		/// <summary>
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed, except via method <see cref="AddOwner(U)"/>.
		/// </summary>
		[IgnoreDataMember]
		public virtual long OwningUserID
		{
			get
			{
				return owningUserID;
			}
			set
			{
				if (owningUserID != value)
				{
					if (owningUserID != 0L && value != 0L)
						throw new AccessDeniedDomainException("The owner of the entity cannot be changed.", this);

					owningUserID = value;
				}
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
				return owningUser;
			}
			set
			{
				if (owningUser != value)
				{
					if (owningUser != null && value != null)
						throw new AccessDeniedDomainException("The owner of the entity cannot be changed.", this);

					owningUser = value;
				}
			}
		}

		/// <summary>
		/// Test whether a user is the owner of the entity.
		/// </summary>
		/// <param name="userID">The ID of the user.</param>
		public bool IsOwnedBy(long userID) => userID == owningUserID;

		/// <summary>
		/// Test whether a user is the owner of the entity.
		/// </summary>
		/// <param name="user">The user.</param>
		public bool IsOwnedBy(U user) => user.ID == owningUserID;

		/// <summary>
		/// Returns true when the entity has an owner, false otherwise.
		/// </summary>
		public bool HasOwners() => owningUserID != 0L || owningUser != null;

		/// <summary>
		/// Set the owner for the entity. Any
		/// previous owner will be replaced.
		/// </summary>
		/// <param name="user">The user to own the entity.</param>
		/// <returns>Always returns true.</returns>
		public bool AddOwner(U user)
		{
			if (user == null) throw new ArgumentNullException(nameof(user));

			owningUserID = user.ID;
			owningUser = user;

			return true;
		}

		#endregion
	}
}

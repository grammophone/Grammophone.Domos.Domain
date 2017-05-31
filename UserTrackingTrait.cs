using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A trait to aid implementation of <see cref="IUserTrackingEntity"/>.
	/// </summary>
	public struct UserTrackingTrait
	{
		#region Private fields

		private long owningUserID;

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public long OwningUserID
		{
			get
			{
				return owningUserID;
			}
			set
			{
				if (owningUserID != value)
				{
					if (owningUserID != 0L)
						throw new AccessDeniedDomainException("The owner of the entity cannot be changed.", this);

					owningUserID = value;
				}
			}
		}

		#endregion
	}

	/// <summary>
	/// A trait to aid implementation of <see cref="IUserTrackingEntity{U}"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public struct UserTrackingTrait<U>
		where U : User
	{
		#region Private fields

		private long owningUserID;

		private U owningUser;

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public long OwningUserID
		{
			get
			{
				return owningUserID;
			}
			set
			{
				if (owningUserID != value && value != 0L)
				{
					if (owningUserID != 0L)
						throw new AccessDeniedDomainException("The owner of the entity cannot be changed.", this);

					owningUserID = value;
				}
			}
		}

		/// <summary>
		/// The owner of the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public U OwningUser
		{
			get
			{
				return owningUser;
			}
			set
			{
				if (owningUser != value && value != null)
				{
					if (owningUser != null)
						throw new AccessDeniedDomainException("The owner of the entity cannot be changed.", this);

					owningUser = value;
				}
			}
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// A trait to aid implementation of <see cref="IUserTrackingEntity{U}"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public struct UserTrackingTrait<U>
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
		public long OwnerUserID
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
		public U OwnerUser
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

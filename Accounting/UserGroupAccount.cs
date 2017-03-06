using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Account owned by a group of users.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class UserGroupAccount<U> : Account, IUserGroupTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private TrackingTrait<U> trackingTrait;

		private UserGroupTrackingTrait<U> userGroupTrackingTrait;

		#endregion

		#region IUserGroupTrackingEntity<U> implementation

		/// <summary>
		/// Date when the entity was created.
		/// Set by the system.
		/// Once set, cannot be changed.
		/// </summary>
		public DateTime CreationDate
		{
			get
			{
				return trackingTrait.CreationDate;
			}
			set
			{
				trackingTrait.CreationDate = value;
			}
		}

		/// <summary>
		/// The owner of the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public U CreatorUser
		{
			get
			{
				return trackingTrait.CreatorUser;
			}
			set
			{
				trackingTrait.CreatorUser = value;
			}
		}

		/// <summary>
		/// ID of the user who created the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public long CreatorUserID
		{
			get
			{
				return trackingTrait.CreatorUserID;
			}
			set
			{
				trackingTrait.CreatorUserID = value;
			}
		}

		/// <summary>
		/// Date of the last modification of the entity.
		/// Set by the system.
		/// </summary>
		public DateTime LastModificationDate
		{
			get
			{
				return trackingTrait.LastModificationDate;
			}
			set
			{
				trackingTrait.LastModificationDate = value;
			}
		}

		/// <summary>
		/// The user who modified the entity last.
		/// </summary>
		public U LastModifierUser
		{
			get
			{
				return trackingTrait.LastModifierUser;
			}
			set
			{
				trackingTrait.LastModifierUser = value;
			}
		}

		/// <summary>
		/// ID of the user who modified the entity last.
		/// </summary>
		public long LastModifierUserID
		{
			get
			{
				return trackingTrait.LastModifierUserID;
			}
			set
			{
				LastModifierUserID = value;
			}
		}

		/// <summary>
		/// The owners of the entity. 
		/// At least when querying for lists of entities, 
		/// please remember to early fetch the owners to avoid a 'n+1' performance hit.
		/// </summary>
		public ICollection<U> OwningUsers
		{
			get
			{
				return userGroupTrackingTrait.OwningUsers;
			}
			set
			{
				userGroupTrackingTrait.OwningUsers = value;
			}
		}

		#endregion
	}
}

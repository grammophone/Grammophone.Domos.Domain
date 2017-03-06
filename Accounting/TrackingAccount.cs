using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// An account with user change tracking.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class TrackingAccount<U> : Account, ITrackingEntity<U>
		where U : User
	{
		#region Private fields

		private TrackingTrait<U> trackingTrait;

		#endregion

		#region ITrackingEntity<U> implementation

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

		#endregion
	}
}

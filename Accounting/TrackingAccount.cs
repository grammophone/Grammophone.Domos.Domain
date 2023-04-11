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
		public virtual DateTime CreationDate
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
		public virtual U CreatorUser
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
		public virtual long CreatorUserID
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
		public virtual DateTime LastModificationDate
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
		public virtual U LastModifierUser
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
		public virtual long LastModifierUserID
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
		/// Record the creator of the account and the creation time.
		/// The method can only be called once.
		/// </summary>
		/// <param name="user">The user creating the account.</param>
		/// <param name="utcTime">The time of creation, in UTC.</param>
		/// <exception cref="ArgumentException">Thrown when the time is not in UTC.</exception>
		/// <exception cref="AccessDeniedDomainException">Thrown when the creator has already been set.</exception>
		public void SetCreator(U user, DateTime utcTime) => trackingTrait.SetCreator(this, user, utcTime);

		/// <summary>
		/// Record a change by a user.
		/// </summary>
		/// <param name="user">The user changing the account.</param>
		/// <param name="utcTime">The time of change of the account, in UTC.</param>
		/// <exception cref="ArgumentException">Thrown when the time is not given in UTC.</exception>
		public virtual void RecordChange(U user, DateTime utcTime) => trackingTrait.RecordChange(this, user, utcTime);

		#endregion
	}
}

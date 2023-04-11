using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// String-type base class for entities supporting change tracking.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class TrackingEntity<U> : ITrackingEntity<U>
		where U : User
	{
		#region Private fields

		private TrackingTrait<U> trackingTrait;

		#endregion

		#region Primitive properties

		/// <summary>
		/// Date when the entity was created, in UTC.
		/// Set by the system.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		[Display(
			ResourceType = typeof(TrackingEntityResources),
			Name = nameof(TrackingEntityResources.CreationDate_Name))]
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
		/// Date of the last modification of the entity, in UTC.
		/// Set by the system.
		/// </summary>
		[IgnoreDataMember]
		[Display(
			ResourceType = typeof(TrackingEntityResources),
			Name = nameof(TrackingEntityResources.LastModificationDate_Name))]
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

		#endregion

		#region Relations

		/// <summary>
		/// ID of the user who created the entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
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
		/// The user who created the entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
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
		/// ID of the user who modified the entity last.
		/// </summary>
		[IgnoreDataMember]
		public virtual long LastModifierUserID
		{
			get
			{
				return trackingTrait.LastModifierUserID;
			}
			set
			{
				trackingTrait.LastModifierUserID = value;
			}
		}

		/// <summary>
		/// The user who modified the entity last.
		/// </summary>
		[IgnoreDataMember]
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

		#endregion

		#region Public methods

		/// <summary>
		/// Record the creator of the entity and the creation time.
		/// The method can only be called once.
		/// </summary>
		/// <param name="user">The user creating the entity.</param>
		/// <param name="utcTime">The time of creation, in UTC.</param>
		/// <exception cref="ArgumentException">Thrown when the time is not in UTC.</exception>
		/// <exception cref="AccessDeniedDomainException">Thrown when the creator has already been set.</exception>
		public void SetCreator(U user, DateTime utcTime) => trackingTrait.SetCreator(this, user, utcTime);

		/// <summary>
		/// Record a change by a user.
		/// </summary>
		/// <param name="user">The user changing the entity.</param>
		/// <param name="utcTime">The time of change of the entity, in UTC.</param>
		/// <exception cref="ArgumentException">Thrown when the time is not given in UTC.</exception>
		public virtual void RecordChange(U user, DateTime utcTime) => trackingTrait.RecordChange(this, user, utcTime);

		#endregion
	}
}

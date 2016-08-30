using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Abstract base for segregated areas of the system, such as companies,
	/// to support software-as-a-service scenarios.
	/// </summary>
	[Serializable]
	public abstract class Segregation : EntityWithID<long>, IUserTrackingEntity, ISegregatedEntity
	{
		#region Private fields

		private TrackingTrait trackingTrait;

		private UserTrackingTrait userTrackingTrait;

		#endregion

		#region Primitive properties

		/// <summary>
		/// This property is bound to <see cref="EntityWithID{K}.ID"/>.
		/// </summary>
		long ISegregatedEntity.SegregationID
		{
			get
			{
				return this.ID;
			}
			set
			{
				this.ID = value;
			}
		}

		/// <summary>
		/// Date when the entity was created.
		/// Set by the system.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
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
		/// Date of the last modification of the entity.
		/// Set by the system.
		/// </summary>
		[IgnoreDataMember]
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
		/// The ID of the user who owns the entity.
		/// Once set, cannot be changed.
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

		#endregion
	}

	/// <summary>
	/// Abstract strong-type base for segregated areas of the system, such as companies,
	/// to support software-as-a-service scenarios.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class Segregation<U> : Segregation, IUserTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private U owningUser;

		private U creatorUser;

		#endregion

		#region Relations

		/// <summary>
		/// The the owner of the disposition.
		/// </summary>
		public virtual U OwningUser
		{
			get
			{
				return owningUser;
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				if (value != owningUser)
				{
					if (owningUser != null)
						throw new DomainAccessDeniedException("The User cannot be changed.", this);

					// Sync the foreign key manually, because the base Disposition entity 
					// only knows the UserID property as a foreign key, not the User property and 
					// the Object-Relational mappers will fail to cope automatically.
					this.OwningUserID = value.ID;

					owningUser = value;
				}
			}
		}

		/// <summary>
		/// The user who created the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public U CreatorUser
		{
			get
			{
				return creatorUser;
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				if (creatorUser != value)
				{
					if (creatorUser != null)
						throw new DomainAccessDeniedException("The creator of the entity cannot be changed.", this);

					creatorUser = value;
				}
			}
		}

		/// <summary>
		/// The user who modified the entity last.
		/// </summary>
		public virtual U LastModifierUser { get; set; }

		#endregion
	}
}

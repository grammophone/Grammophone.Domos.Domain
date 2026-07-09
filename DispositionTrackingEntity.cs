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
	/// Base class for entities belonging to a segregation 
	/// and supporting user disposition ownership and change tracking against that segregation.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	/// <typeparam name="D">The type of the disposition, derived from <see cref="Disposition"/>.</typeparam>
	[Serializable]
	public abstract class DispositionTrackingEntity<U, S, D> :
		SegregatedEntity<U, S>, IDispositionTrackingEntity<U, S, D>
		where U : User
		where S : Segregation<U>
		where D : Disposition
	{
		#region Private fields

		private long owningDispositionID;

		private D owningDisposition;

		private DateTime creationDate;

		private long creatorUserID;

		private U creatorUser;

		#endregion

		#region Primitive properties

		/// <summary>
		/// Date when the entity was created.
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
				return creationDate;
			}
			set
			{
				if (creationDate == default(DateTime))
				{
					creationDate = value;
				}
			}
		}

		/// <summary>
		/// Date of the last modification of the entity.
		/// Set by the system.
		/// </summary>
		[IgnoreDataMember]
		[Display(
			ResourceType = typeof(TrackingEntityResources),
			Name = nameof(TrackingEntityResources.LastModificationDate_Name))]
		public virtual DateTime LastModificationDate { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual long OwningDispositionID
		{
			get
			{
				return owningDispositionID;
			}
			set
			{
				if (owningDispositionID != value)
				{
					if (owningDispositionID != 0L)
						throw new AccessDeniedDomainException("The owning disposition ID cannot be changed.", this);

					owningDispositionID = value;
				}
			}
		}

		/// <summary>
		/// The disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual D OwningDisposition
		{
			get
			{
				return owningDisposition;
			}
			set
			{
				if (owningDisposition != value)
				{
					if (owningDisposition != null)
						throw new AccessDeniedDomainException("The owning disposition ID cannot be changed.", this);

					owningDisposition = value;
				}
			}
		}

		/// <summary>
		/// ID of the user who created the entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual long CreatorUserID
		{
			get
			{
				return creatorUserID;
			}
			set
			{
				if (creatorUserID != value)
				{
					if (value != 0L)
					{
						if (creatorUserID != 0L)
							throw new AccessDeniedDomainException("The creator of the entity cannot be changed.", this);

						creatorUserID = value;
					}
				}
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
				return creatorUser;
			}
			set
			{
				if (creatorUser != value)
				{
					if (creatorUser != null && value != null)
						throw new AccessDeniedDomainException("The creator of the entity cannot be changed.", this);

					creatorUser = value;
				}
			}
		}

		/// <summary>
		/// ID of the user who modified the entity last.
		/// </summary>
		[IgnoreDataMember]
		public virtual long LastModifierUserID { get; set; }

		/// <summary>
		/// The user who modified the entity last.
		/// </summary>
		[IgnoreDataMember]
		public virtual U LastModifierUser { get; set; }

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
		public void SetCreator(U user, DateTime utcTime)
		{
			if (user == null) throw new ArgumentNullException(nameof(user));
			if (utcTime.Kind != DateTimeKind.Utc) throw new ArgumentException("The time should be in UTC.", nameof(utcTime));

			this.CreatorUser = user;
			this.CreatorUserID = user.ID;

			this.CreationDate = utcTime;
		}

		/// <summary>
		/// Record a change by a user.
		/// </summary>
		/// <param name="user">The user changing the entity.</param>
		/// <param name="utcTime">The time of change of the entity, in UTC.</param>
		/// <exception cref="ArgumentException">Thrown when the time is not given in UTC.</exception>
		public virtual void RecordChange(U user, DateTime utcTime)
		{
			if (user == null) throw new ArgumentNullException(nameof(user));
			if (utcTime.Kind != DateTimeKind.Utc) throw new ArgumentException("The time should be in UTC.", nameof(utcTime));

			this.LastModifierUser = user;

			// Set the foreign key as well only for inserted entities.
			if (this.LastModifierUserID == 0L) this.LastModifierUserID = user.ID;

			this.LastModificationDate = utcTime;
		}

		#endregion
	}
}

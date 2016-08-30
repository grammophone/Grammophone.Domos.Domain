using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A participation of a user to a segregation of the system.
	/// </summary>
	[Serializable]
	public class Disposition : EntityWithID<long>, IUserTrackingEntity
	{
		#region Private fields

		internal TrackingTrait trackingTrait;

		internal UserTrackingTrait userTrackingTrait;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The ID of the segregation.
		/// </summary>
		public virtual long SegregationID { get; set; }

		/// <summary>
		/// The state of this disposition.
		/// </summary>
		public virtual DispositionState State { get; set; }

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

		#endregion

		#region Relationships

		/// <summary>
		/// The ID of the owner of the disposition.
		/// Once set, cannot be changed.
		/// </summary>
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
		/// The ID of the type of the disposition for this <see cref="SegregationID"/>.
		/// </summary>
		public virtual long TypeID { get; set; }

		/// <summary>
		/// The type of the disposition for this <see cref="SegregationID"/>.
		/// </summary>
		public virtual DispositionType Type { get; set; }

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
				trackingTrait.LastModifierUserID = value;
			}
		}

		#endregion
	}

	/// <summary>
	/// A participation of a user to a segregation of the system,
	/// with strong-type reference to the user.
	/// </summary>
	/// <typeparam name="U">The type of the user.</typeparam>
	[Serializable]
	public class Disposition<U> : Disposition, IUserTrackingEntity<U>
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

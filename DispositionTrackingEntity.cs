using System;
using System.Collections.Generic;
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
	/// <typeparam name="D">The type of the disposition, derived from <see cref="Disposition{U, S}"/>.</typeparam>
	[Serializable]
	public abstract class DispositionTrackingEntity<U, S, D> :
		SegregatedEntity<U, S>, IDispositionTrackingEntity<U, S, D>
		where U : User
		where S : Segregation<U>
		where D : Disposition<U, S>
	{
		#region Private fields

		private DispositionTrackingTrait<U, S, D> dispositionTrackingTrait;

		private TrackingTrait<U> trackingTrait;

		#endregion

		#region Primitive properties

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
		/// The ID of the disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual long OwningDispositionID
		{
			get
			{
				return dispositionTrackingTrait.OwningDispositionID;
			}
			set
			{
				dispositionTrackingTrait.OwningDispositionID = value;
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
				return dispositionTrackingTrait.OwningDisposition;
			}
			set
			{
				dispositionTrackingTrait.OwningDisposition = value;
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
	}
}

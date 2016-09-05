using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// An account owned by a <see cref="Disposition"/>
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	/// <typeparam name="D">The type of the disposition, derived from <see cref="Disposition"/>.</typeparam>
	[Serializable]
	public class DispositionAccount<U, S, D> : Account, IDispositionTrackingEntity<U, S, D>
		where U : User
		where S : Segregation<U>
		where D : Disposition
	{
		#region Private fields

		private TrackingTrait<U> trackingTrait;

		private SegregatedTrait<U, S> segregationTrackingTrait;

		private DispositionTrackingTrait<U, S, D> dispositionTrackingTrait;

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
		/// The ID of the segregation where this entity belongs.
		/// Once set, cannot be changed.
		/// </summary>
		public virtual long SegregationID
		{
			get
			{
				return segregationTrackingTrait.SegregationID;
			}

			set
			{
				segregationTrackingTrait.SegregationID = value;
			}
		}

		/// <summary>
		/// The segregation where this entity belongs.
		/// Once set, cannot be changed.
		/// </summary>
		public virtual S Segregation
		{
			get
			{
				return segregationTrackingTrait.Segregation;
			}
			set
			{
				segregationTrackingTrait.Segregation = value;
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

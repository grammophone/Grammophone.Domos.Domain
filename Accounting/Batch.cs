using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// A batch of single-entry accounting records intended to represent
	/// external system inflow or outflow, where a double-entry recording cannot be kept.
	/// </summary>
	[Serializable]
	public abstract class Batch : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// The ID of the transaction according to the <see cref="CreditSystem"/>.
		/// </summary>
		[Required]
		public virtual string TransactionID { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the external credit system associated with this batch.
		/// </summary>
		public virtual long CreditSystemID { get; set; }

		/// <summary>
		/// The external credit system associated with this batch.
		/// </summary>
		public virtual CreditSystem CreditSystem { get; set; }

		#endregion
	}

	/// <summary>
	/// A batch of single-entry accounting records intended to represent
	/// external system inflow or outflow, where a double-entry recording cannot be kept.
	/// </summary>
	[Serializable]
	public class Batch<U> : Batch, IUserGroupTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private ICollection<BatchRemittance<U>> remittances;

		private TrackingTrait<U> trackingTrait;

		private UserGroupTrackingTrait<U> userGroupTrackingTrait;

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
		/// The remittances belonging to this batch.
		/// </summary>
		public virtual ICollection<BatchRemittance<U>> Remittances
		{
			get
			{
				return remittances ?? (remittances = new HashSet<BatchRemittance<U>>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				remittances = value;
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

		/// <summary>
		/// The owners of the entity. 
		/// At least when querying for lists of entities, 
		/// please remember to early fetch the owners to avoid a 'n+1' performance hit.
		/// </summary>
		[IgnoreDataMember]
		public virtual ICollection<U> OwningUsers
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

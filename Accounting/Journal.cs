using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Base for accounting journals.
	/// </summary>
	[Serializable]
	public abstract class Journal : EntityWithID<long>
	{
		#region Private fields

		private ICollection<JournalLine> lines;

		#endregion

		#region Primitive properties

		/// <summary>
		/// Applicatoin-defined categorization of the journal.
		/// </summary>
		public virtual int Type { get; set; }

		/// <summary>
		/// Optional description of the journal.
		/// </summary>
		public virtual string Description { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The lines contained in this journal.
		/// </summary>
		public virtual ICollection<JournalLine> Lines
		{
			get
			{
				return lines ?? (lines = new HashSet<JournalLine>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				lines = value;
			}
		}

		#endregion
	}

	/// <summary>
	/// Base for accounting journals, having group ownership.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class Journal<U> : Journal, IUserGroupTrackingEntity<U>
		where U : User
	{
		#region Private fields

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
		/// Optional ID of the workflow state transition associated with this journal.
		/// </summary>
		public virtual long? StateTransitionID { get; set; }

		/// <summary>
		/// Optional workflow state transition associated with this journal.
		/// </summary>
		public virtual Workflow.StateTransition<U> StateTransition { get; set; }

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

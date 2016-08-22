using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base class for entities supporting change tracking.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class TrackingEntity<U>
		where U : User
	{
		#region Private fields

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
		public virtual DateTime CreationDate
		{
			get
			{
				return creationDate;
			}
			set
			{
				if (creationDate != value)
				{
					if (creationDate != default(DateTime))
						throw new DomainAccessDeniedException("The creation date cannot be changed.", this);

					creationDate = value;
				}
			}
		}

		/// <summary>
		/// Date of the last modification of the entity.
		/// Set by the system.
		/// </summary>
		[IgnoreDataMember]
		public virtual DateTime LastModificationDate { get; set; }

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
				return creatorUserID;
			}
			set
			{
				if (creatorUserID != value)
				{
					if (creatorUserID != 0L)
						throw new DomainAccessDeniedException("The creator of the entity cannot be changed.", this);

					creatorUserID = value;
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
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Files
{
	/// <summary>
	/// A file tracking user write access.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class TrackingFile<U> : File, ITrackingEntity<U>
		where U : User
	{
		#region Private fields

		private DateTime creationDate;

		private long creatorUserID;

		private U creatorUser;

		#endregion

		#region Public properties

		/// <summary>
		/// Date when the entity was created.
		/// Set by the system.
		/// Once set, cannot be changed.
		/// </summary>
		[Display(
			ResourceType = typeof(FileResources),
			Name = nameof(FileResources.CreationDate_Name))]
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
		[Display(
			ResourceType = typeof(FileResources),
			Name = nameof(FileResources.LastModificationDate_Name))]
		public virtual DateTime LastModificationDate { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The user who created the entity.
		/// Once set, cannot be changed.
		/// </summary>
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
		/// ID of the user who created the entity.
		/// Once set, cannot be changed.
		/// </summary>
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
		/// The user who modified the entity last.
		/// </summary>
		public virtual U LastModifierUser { get; set; }

		/// <summary>
		/// ID of the user who modified the entity last.
		/// </summary>
		public virtual long LastModifierUserID { get; set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Record the creator of the file and the creation time.
		/// The method can only be called once.
		/// </summary>
		/// <param name="user">The user creating the file.</param>
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
		/// <param name="user">The user changing the file.</param>
		/// <param name="utcTime">The time of change of the file, in UTC.</param>
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

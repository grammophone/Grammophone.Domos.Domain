using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A trait to aid implementation of <see cref="ITrackingEntity"/>.
	/// </summary>
	public struct TrackingTrait
	{
		#region Private fields

		private DateTime creationDate;

		private long creatorUserID;

		#endregion

		#region Primitive properties

		/// <summary>
		/// Date when the entity was created.
		/// Set by the system.
		/// Once set, cannot be changed.
		/// </summary>
		public DateTime CreationDate
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
						throw new AccessDeniedDomainException("The creation date cannot be changed.", this);

					creationDate = value;
				}
			}
		}

		/// <summary>
		/// Date of the last modification of the entity.
		/// Set by the system.
		/// </summary>
		public DateTime LastModificationDate { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// ID of the user who created the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public long CreatorUserID
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
						throw new AccessDeniedDomainException("The creator of the entity cannot be changed.", this);

					creatorUserID = value;
				}
			}
		}

		/// <summary>
		/// ID of the user who modified the entity last.
		/// </summary>
		public long LastModifierUserID { get; set; }

		#endregion
	}

	/// <summary>
	/// A trait to aid implementation of <see cref="ITrackingEntity{U}"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public struct TrackingTrait<U>
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
		public DateTime CreationDate
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
				else if (value < creationDate)
				{
					throw new AccessDeniedDomainException("The creation date cannot be changed.", this);
				}
			}
		}

		/// <summary>
		/// Date of the last modification of the entity.
		/// Set by the system.
		/// </summary>
		public DateTime LastModificationDate { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// ID of the user who created the entity.
		/// Once set, cannot be changed.
		/// </summary>
		public long CreatorUserID
		{
			get
			{
				return creatorUserID;
			}
			set
			{
				if (creatorUserID != value)
				{
					if (creatorUserID != 0L && value != 0L)
						throw new AccessDeniedDomainException("The creator of the entity cannot be changed.", this);

					creatorUserID = value;
				}
			}
		}

		/// <summary>
		/// The user who created the entity.
		/// </summary>
		public U CreatorUser
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
		public long LastModifierUserID { get; set; }

		/// <summary>
		/// The user who modified the entity last.
		/// </summary>
		public U LastModifierUser { get; set; }

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
		public void RecordChange(U user, DateTime utcTime)
		{
			if (user == null) throw new ArgumentNullException(nameof(user));
			if (utcTime.Kind != DateTimeKind.Utc) throw new ArgumentException("The time should be in UTC.", nameof(utcTime));

			this.LastModifierUser = user;
			this.LastModifierUserID = user.ID;

			this.LastModificationDate = utcTime;
		}

		#endregion
	}
}

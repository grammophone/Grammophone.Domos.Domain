﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A user in the system.
	/// </summary>
	[Serializable]
	public class User : EntityWithID<long>
	{
		#region Private fields

		private ICollection<Role> roles;

		private ICollection<Disposition> dispositions;

		private ICollection<Registration> registrations;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The user's code name.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[IgnoreDataMember]
		public virtual string UserName { get; set; }

		/// <summary>
		/// The user's e-mail.
		/// </summary>
		[EmailAddress]
		[Required]
		[MaxLength(256)]
		[IgnoreDataMember]
		public virtual string Email { get; set; }

		/// <summary>
		/// Optional password hash, used only when 
		/// using native registration.
		/// </summary>
		[MaxLength(1024)]
		[IgnoreDataMember]
		public virtual string PaswordHash { get; set; }

		/// <summary>
		/// First name.
		/// </summary>
		[Required]
		[MaxLength(256)]
		public virtual string FirstName { get; set; }

		/// <summary>
		/// Last name.
		/// </summary>
		[Required]
		[MaxLength(256)]
		public virtual string LastName { get; set; }

		/// <summary>
		/// True if this is a system account.
		/// </summary>
		[IgnoreDataMember]
		public virtual bool IsSystem { get; set; }

		/// <summary>
		/// True if the user is the special "Anonymous" one.
		/// </summary>
		[IgnoreDataMember]
		public virtual bool IsAnonymous { get; set; }

		/// <summary>
		/// The registration status of the user.
		/// </summary>
		public virtual RegistrationStatus RegistrationStatus { get; set; }

		/// <summary>
		/// A security stamp that is updated whenever there is a change in the user's credentials.
		/// </summary>
		[IgnoreDataMember]
		[MaxLength(512)]
		[Required(AllowEmptyStrings = true)]
		public virtual string SecurityStamp { get; set; }

		/// <summary>
		/// Date when the user was created.
		/// </summary>
		public virtual DateTime CreationDate { get; set; }

		/// <summary>
		/// An optional unique identifier for the user.
		/// </summary>
		/// <remarks>
		/// This is not elected as the primary key for two reasons:
		/// <list type="bullet">
		/// <item>It is intended to be unpredictable.</item>
		/// <item>The <see cref="EntityWithID{K}.ID"/> is more lightweight as a primary and foreign key.</item>
		/// </list>
		/// </remarks>
		public virtual Guid Guid { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The system-wide roles of the user.
		/// </summary>
		public virtual ICollection<Role> Roles
		{
			get
			{
				return roles ?? (roles = new HashSet<Role>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				roles = value;
			}
		}

		/// <summary>
		/// The segregation-wide roles of the user.
		/// </summary>
		public virtual ICollection<Disposition> Dispositions
		{
			get
			{
				return dispositions ?? (dispositions = new HashSet<Disposition>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				dispositions = value;
			}
		}

		/// <summary>
		/// The external login registrations of the user.
		/// </summary>
		public virtual ICollection<Registration> Registrations
		{
			get
			{
				return registrations ?? (registrations = new HashSet<Registration>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				registrations = value;
			}
		}

		#endregion
	}
}

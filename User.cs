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
	/// A user in the system.
	/// </summary>
	[Serializable]
	public class User
	{
		#region Private fields

		private ICollection<Role> roles;

		private ICollection<Disposition> dispositions;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The primary key.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// The user's e-mail serving as the user's name.
		/// </summary>
		[EmailAddress]
		[Required]
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
		public virtual bool IsSystem { get; set; }

		/// <summary>
		/// True if the user is the special "Anonymous" one.
		/// </summary>
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

		#endregion
	}
}

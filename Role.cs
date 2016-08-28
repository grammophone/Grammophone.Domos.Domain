using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Role assigned to users.
	/// </summary>
	[Serializable]
	public class Role : EntityWithID<long>
	{
		#region Private fields

		private ICollection<User> users;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The name of the role.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string Name { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The set of users having the role.
		/// </summary>
		public virtual ICollection<User> Users
		{
			get
			{
				return users ?? (users = new HashSet<User>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));
				users = value;
			}
		}

		#endregion
	}
}

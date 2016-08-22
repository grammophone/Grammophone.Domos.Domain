using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// An abstraction for a session API access.
	/// </summary>
	[Serializable]
	public class ManagerAccess
	{
		#region Primitive properties

		/// <summary>
		/// The primary key. User only when stored in database.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// A session manager class name serving the permission.
		/// </summary>
		[Required]
		public virtual string ClassName { get; set; }

		#endregion
	}
}

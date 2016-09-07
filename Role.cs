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
		#region Primitive properties

		/// <summary>
		/// The name of the role.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string Name { get; set; }

		/// <summary>
		/// The code name of the role.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string CodeName { get; set; }

		#endregion
	}
}

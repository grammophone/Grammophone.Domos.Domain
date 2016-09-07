using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A segregation-wide role.
	/// </summary>
	[Serializable]
	public class DispositionType : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// The name of the segregation-wide role.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string Name { get; set; }

		/// <summary>
		/// The code name of a the segregation-wide role.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// The full .NET class name of dispositions of this type.
		/// </summary>
		[Required]
		[MaxLength(512)]
		public virtual string ClassName { get; set; }

		#endregion
	}
}

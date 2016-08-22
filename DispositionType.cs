using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// A segregation-wide role.
	/// </summary>
	[Serializable]
	public class DispositionType
	{
		#region Primitive properties

		/// <summary>
		/// The primary key.
		/// </summary>
		public virtual long ID { get; set; }
		
		/// <summary>
		/// The name of a segregation-wide role.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// The full .NET class name of dispositions of this type.
		/// </summary>
		public virtual string ClassName { get; set; }

		#endregion
	}
}

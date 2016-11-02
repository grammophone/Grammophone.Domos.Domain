using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Files
{
	/// <summary>
	/// Represents a MIME content type.
	/// </summary>
	[Serializable]
	public class ContentType : EntityWithID<int>
	{
		#region Primitive properties

		/// <summary>
		/// The MIME type.
		/// </summary>
		public virtual string MIME { get; set; }

		/// <summary>
		/// The friendly name of the content type.
		/// </summary>
		public virtual string Name { get; set; }

		#endregion
	}
}

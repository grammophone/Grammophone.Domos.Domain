using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Files
{
	/// <summary>
	/// Contract to be implemented by file entities.
	/// If the file's container is configured for public access, its URL is 
	/// http[s]://&lt;storage base&gt;/&lt;<see cref="ContainerName"/>&gt;/&lt;<see cref="FullName"/>&gt;,
	/// possibly escaping the <see cref="FullName"/> using <see cref="Uri.EscapeUriString(string)"/>.
	/// </summary>
	public interface IFile
	{
		#region Primitive properties

		/// <summary>
		/// The name of the file's container.
		/// </summary>
		string ContainerName { get; set; }

		/// <summary>
		/// The full name of the file relative to its container.
		/// </summary>
		string FullName { get; set; }

		/// <summary>
		/// The friendly name of the file.
		/// </summary>
		string Name { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the content type of the file.
		/// </summary>
		int ContentTypeID { get; set; }

		/// <summary>
		/// The content type of the file.
		/// </summary>
		ContentType ContentType { get; set; }

		#endregion
	}
}

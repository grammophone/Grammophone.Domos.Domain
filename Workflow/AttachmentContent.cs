using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Workflow
{
	/// <summary>
	/// Holds optional binary contents of an <see cref="Attachment"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public class AttachmentContent<U> : UserGroupTrackingEntity<U>
		where U : User
	{
		#region Primitive properties

		/// <summary>
		/// The primary key, set up for one to one mapping with <see cref="Attachment{U}"/>.
		/// </summary>
		[Key, ForeignKey("Attachment")]
		public virtual long ID { get; set; }

		/// <summary>
		/// The MIME type of the contents.
		/// </summary>
		[Required]
		[MaxLength(512)]
		public virtual string MIMEType { get; set; }

		/// <summary>
		/// The bytes of the contents.
		/// </summary>
		[Required]
		public virtual byte[] Bytes { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The attachment where content belongs.
		/// </summary>
		public virtual Attachment<U> Attachment { get; set; }

		#endregion
	}
}

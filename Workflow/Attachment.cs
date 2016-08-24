using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Workflow
{
	/// <summary>
	/// An attachment accompanying a <see cref="StateTransition{U}"/>
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public class Attachment<U> : UserGroupTrackingEntity<U>
		where U : User
	{
		#region Primitive properties

		/// <summary>
		/// The primary key.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// An application-defined attachment type.
		/// </summary>
		public int Type { get; set; }

		/// <summary>
		/// Optional title of the attachment.
		/// </summary>
		[MaxLength(256)]
		public virtual string Title { get; set; }

		/// <summary>
		/// Optional text of the attachment.
		/// </summary>
		public virtual string Text { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the optional content of the attachment.
		/// </summary>
		public virtual long? ContentID { get; set; }

		/// <summary>
		/// The optional content of the attachment.
		/// </summary>
		public virtual AttachmentContent<U> Content { get; set; }

		#endregion
	}
}

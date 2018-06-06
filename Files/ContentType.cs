using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		/// The MIME code.
		/// </summary>
		[MaxLength(128)]
		[Required]
		[Display(
			ResourceType = typeof(ContentTypeResources),
			Name = nameof(ContentTypeResources.MIME_Name),
			Description = nameof(ContentTypeResources.MIME_Description))]
		public virtual string MIME { get; set; }

		/// <summary>
		/// The display name of the content type.
		/// </summary>
		[MaxLength(512)]
		[Required]
		[Display(
			ResourceType = typeof(ContentTypeResources),
			Name = nameof(ContentTypeResources.MIME_Name),
			Description = nameof(ContentTypeResources.Name_Description))]
		public virtual string Name { get; set; }

		#endregion
	}
}

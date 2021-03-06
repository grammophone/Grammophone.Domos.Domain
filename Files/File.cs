﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Files
{
	/// <summary>
	/// Represents a file hosted in a container of a storage system.
	/// If the file's container is configured for public access, its URL is 
	/// http[s]://&lt;storage base&gt;/&lt;<see cref="ContainerName"/>&gt;/&lt;<see cref="FullName"/>&gt;,
	/// possibly escaping the <see cref="FullName"/> using <see cref="Uri.EscapeUriString(string)"/>.
	/// </summary>
	/// <remarks>
	/// This entity is abstract with no entity set; 
	/// derive from it and define your own entity set.
	/// Consider deriving from the generic abstract descendants <see cref="TrackingFile{U}"/>
	/// and <see cref="UserTrackingFile{U}"/> to get user tracking for free.
	/// </remarks>
	[Serializable]
	public abstract class File : EntityWithID<long>, IFile
	{
		#region Primitive properties

		/// <summary>
		/// The name of the file's container.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string ContainerName { get; set; }

		/// <summary>
		/// The name of the storage provider name.
		/// If null, it specifies the default storage provider.
		/// </summary>
		[MaxLength(32)]
		public virtual string ProviderName { get; set; }

		/// <summary>
		/// The full name of the file relative to its container.
		/// </summary>
		[Required]
		[MaxLength(1024)]
		[Display(
			ResourceType = typeof(FileResources),
			Name = nameof(FileResources.FullName_Name),
			Description = nameof(FileResources.FullName_Description))]
		public virtual string FullName { get; set; }

		/// <summary>
		/// The name of the file.
		/// </summary>
		[Required]
		[MaxLength(512)]
		[Display(
			ResourceType = typeof(FileResources),
			Name = nameof(FileResources.Name_Name),
			Description = nameof(FileResources.Name_Description))]
		public virtual string Name { get; set; }

		/// <summary>
		/// If true, the file contents are encrypted.
		/// </summary>
		public virtual bool IsEncrypted { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the content type of the file.
		/// </summary>
		public virtual int ContentTypeID { get; set; }

		/// <summary>
		/// The content type of the file.
		/// </summary>
		public virtual ContentType ContentType { get; set; }

		#endregion
	}
}

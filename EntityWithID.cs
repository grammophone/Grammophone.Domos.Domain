using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Base for entities having a primary key
	/// of a generic type <typeparamref name="K"/>.
	/// </summary>
	/// <typeparam name="K">The type of primary key.</typeparam>
	/// <remarks>
	/// Implements <see cref="IEntityWithID{K}"/>.
	/// </remarks>
	[Serializable]
	public abstract class EntityWithID<K> : IEntityWithID<K>
	{
		/// <summary>
		/// The primary key.
		/// </summary>
		[Required]
		[Key]
		[Display(
			ResourceType = typeof(EntityWithIdResources),
			Name = nameof(EntityWithIdResources.ID_Name))]
		public virtual K ID { get; set; }
	}
}

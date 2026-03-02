using System;
using System.Collections.Generic;
using System.Text;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Interface for an entity with a primary key.
	/// </summary>
	/// <typeparam name="K"></typeparam>
	public interface IEntityWithPrimaryKey<K> : IEntityWithID<K>
	{
		/// <summary>
		/// The ID field.
		/// </summary>
		new K ID { get;  set; }
	}
}

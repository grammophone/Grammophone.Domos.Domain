using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A contract for entities having a primary key.
	/// </summary>
	/// <typeparam name="K">The type of primary key.</typeparam>
	public interface IEntityWithID<K>
	{
		/// <summary>
		/// The primary key.
		/// </summary>
		K ID { get; set; }
	}

}

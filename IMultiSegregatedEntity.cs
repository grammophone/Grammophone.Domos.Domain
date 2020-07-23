using System;
using System.Collections.Generic;
using System.Text;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Contract for entities belonging to multiple segregations.
	/// </summary>
	public interface IMultiSegregatedEntity
	{
		/// <summary>
		/// The collection of IDs of the abstract segregations where this entity belongs to.
		/// For example, in a platform-as-a-service scenario, these could be the IDs of the companies where the entity belongs.
		/// </summary>
		IEnumerable<long> SegregationIDs { get; }
	}
}

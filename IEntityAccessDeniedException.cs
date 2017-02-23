using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Interface to mark an exception as an access denial for an entity.
	/// </summary>
	public interface IEntityAccessDeniedException
	{
		/// <summary>
		/// The type name of the entity under violation.
		/// </summary>
		string EntityName { get; }
	}
}

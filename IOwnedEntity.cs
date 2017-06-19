using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Implemented by entities which can report ownership.
	/// </summary>
	public interface IOwnedEntity<in U>
		where U : User
	{
		/// <summary>
		/// Test whether a user is the owner of the entity.
		/// </summary>
		/// <param name="user">The user.</param>
		bool IsOwnedBy(U user);
	}
}

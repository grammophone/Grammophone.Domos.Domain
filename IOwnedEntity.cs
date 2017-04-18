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
	public interface IOwnedEntity
	{
		/// <summary>
		/// Test whether a user is the owner of the entity.
		/// </summary>
		/// <param name="userID">The ID of the user.</param>
		bool IsOwnedBy(long userID);
	}

	/// <summary>
	/// Implemented by entities which can report ownership.
	/// </summary>
	public interface IOwnedEntity<in U> : IOwnedEntity
		where U : User
	{
		/// <summary>
		/// Test whether a user is the owner of the entity.
		/// </summary>
		/// <param name="user">The user.</param>
		bool IsOwnedBy(U user);
	}
}

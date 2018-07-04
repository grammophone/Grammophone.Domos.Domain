using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Implemented by entities which can report and update ownership.
	/// </summary>
	public interface IUpdatableOwnerEntity<in U> : IOwnedEntity<U>
		where U : User
	{
		/// <summary>
		/// Returns true when the entity has at least one owner, false otherwise.
		/// </summary>
		bool HasOwners();

		/// <summary>
		/// Add an owner for the entity. If the entity only supports a single owner, any
		/// previous owners will be replaced.
		/// </summary>
		/// <param name="user">The user to own the entity.</param>
		/// <returns>Returns true if the user was successfully set as an owner, false otherwise.</returns>
		bool AddOwner(U user);
	}
}

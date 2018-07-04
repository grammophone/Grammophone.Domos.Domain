using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Implemented by entities recording their creator and the time of creation.
	/// </summary>
	/// <typeparam name="U">The type of user creating the entity, derived from <see cref="User"/>.</typeparam>
	public interface ICreationLoggingEntity<in U>
	{
		/// <summary>
		/// Record the creator of the entity and the creation time.
		/// The method can only be called once.
		/// </summary>
		/// <param name="user">The user creating the entity.</param>
		/// <param name="utcTime">The time of creation, in UTC.</param>
		/// <exception cref="AccessDeniedDomainException">Thrown when the creator has already been set.</exception>
		/// <exception cref="ArgumentException">Thrown when the time is not in UTC.</exception>
		void SetCreator(U user, DateTime utcTime);
	}
}

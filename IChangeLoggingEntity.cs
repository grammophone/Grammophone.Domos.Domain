using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Implemented by entities able to record a change.
	/// </summary>
	/// <typeparam name="U">The type of the user causing the change.</typeparam>
	public interface IChangeLoggingEntity<in U>
		where U : User
	{
		/// <summary>
		/// Record a change by a user.
		/// </summary>
		/// <param name="user">The user changing the entity.</param>
		/// <param name="utcTime">The time of change of the entity, in UTC.</param>
		/// <exception cref="ArgumentException">Thrown when the time is not given in UTC.</exception>
		void RecordChange(U user, DateTime utcTime);
	}
}

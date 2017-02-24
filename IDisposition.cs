using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Interface for disposition entities.
	/// </summary>
	public interface IDisposition : IUserTrackingEntity<User>
	{
		/// <summary>
		/// The state of this disposition.
		/// </summary>
		DispositionStatus Status { get; set; }

		/// <summary>
		/// The ID of the segregation.
		/// </summary>
		long SegregationID { get; }

		/// <summary>
		/// The ID of the type of this disposition.
		/// </summary>
		long TypeID { get; set; }

		/// <summary>
		/// The type of this disposition.
		/// </summary>
		DispositionType Type { get; set; }
	}

	/// <summary>
	/// Interface for disposition entities with strong-type
	/// relationship to the segregation.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	public interface IDisposition<U, S> : IDisposition
		where U : User
		where S : Segregation<U>
	{
		/// <summary>
		/// The segregation.
		/// </summary>
		S Segregation { get; set; }
	}
}

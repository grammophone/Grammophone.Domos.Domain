using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Contract for entities belonging to a segregation.
	/// </summary>
	public interface ISegregationTrackingEntity
	{
		/// <summary>
		/// The ID of the abstract segregation where this entity belongs to.
		/// For example, in a platform-as-a-service scenario, this could be the company ID.
		/// Once set, cannot be changed.
		/// </summary>
		long SegregationID { get; set; }
	}

	/// <summary>
	/// Strong-type contract for entities belonging to a segregation.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/></typeparam>
	public interface ISegregationTrackingEntity<U, S> : ISegregationTrackingEntity
		where U : User
		where S : Segregation<U>
	{
		/// <summary>
		/// The segregation where this entity belongs to.
		/// For example, in a platform-as-a-service scenario, this could be the company.
		/// Once set, cannot be changed.
		/// </summary>
		S Segregation { get; set; }
	}
}

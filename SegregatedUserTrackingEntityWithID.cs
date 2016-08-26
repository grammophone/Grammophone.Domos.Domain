using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base class for entities having a primary key and
	/// supporting user ownership and change tracking
	/// as well as belonging to a segregation.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="K">The type of primary key.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	[Serializable]
	public abstract class SegregatedUserTrackingEntityWithID<U, K, S> :
		SegregatedUserTrackingEntity<U, S>, IEntityWithID<K>
		where U : User
		where S : Segregation<U>
	{
		/// <summary>
		/// The primary key.
		/// </summary>
		[Required]
		[Key]
		public virtual K ID { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base class for entities having a primary key annd belonging to a segregation 
	/// and supporting user disposition ownership and change tracking against that segregation.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="K">The type of primary key.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	/// <typeparam name="D">The type of the disposition, derived from <see cref="Disposition{U}"/>.</typeparam>
	[Serializable]
	public abstract class DispositionTrackingEntityWithID<U, K, S, D> :
		DispositionTrackingEntity<U, S, D>, IEntityWithID<K>
		where U : User
		where S : Segregation<U>
		where D : Disposition<U>
	{
		/// <summary>
		/// The primary key.
		/// </summary>
		[Required]
		[Key]
		public virtual K ID { get; set; }
	}
}

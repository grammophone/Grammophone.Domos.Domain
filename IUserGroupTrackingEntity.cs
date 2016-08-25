using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Implemented by entities supporting group ownership.
	/// Remember to eager fetch the <see cref="OwningUsers"/> property
	/// when retrieving a list of entities implementing this interface to avoid a 'n+1' performance penalty.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	public interface IUserGroupTrackingEntity<U> : ITrackingEntity<U>
		where U : User
	{
		/// <summary>
		/// The owners of the entity. 
		/// At least when querying for lists of entities, 
		/// please remember to early fetch the owners to avoid 'n+1' performance hit.
		/// </summary>
		ICollection<U> OwningUsers { get; }
	}
}

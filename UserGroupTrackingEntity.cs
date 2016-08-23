using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base for entities supporting group ownership.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class UserGroupTrackingEntity<U> : TrackingEntity<U>, IUserGroupTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private ICollection<U> ownerUsers;

		#endregion

		#region Relations

		/// <summary>
		/// The owners of the entity. 
		/// At least when querying for lists of entities, 
		/// please remember to early fetch the owners to avoid 'n+1' performance hit.
		/// </summary>
		public ICollection<U> OwnerUsers
		{
			get
			{
				return ownerUsers ?? (ownerUsers = new HashSet<U>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				ownerUsers = value;
			}
		}

		#endregion
	}
}

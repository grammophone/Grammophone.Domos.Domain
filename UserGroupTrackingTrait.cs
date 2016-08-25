using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// A trait to aid implementation of <see cref="IUserGroupTrackingEntity{U}"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public struct UserGroupTrackingTrait<U>
		where U : User
	{
		#region Private fields

		private ICollection<U> ownerUsers;

		#endregion

		#region Relations

		/// <summary>
		/// The owners of the entity. 
		/// At least when querying for lists of entities, 
		/// please remember to early fetch the owners to avoid a 'n+1' performance hit.
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

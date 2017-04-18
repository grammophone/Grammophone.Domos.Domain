using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
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

		private UserGroupTrackingTrait<U> userGroupTrackingTrait;

		#endregion

		#region Relations

		/// <summary>
		/// The owners of the entity. 
		/// At least when querying for lists of entities, 
		/// please remember to early fetch the owners to avoid a 'n+1' performance hit.
		/// </summary>
		[IgnoreDataMember]
		public virtual ICollection<U> OwningUsers
		{
			get
			{
				return userGroupTrackingTrait.OwningUsers;
			}
			set
			{
				userGroupTrackingTrait.OwningUsers = value;
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Test whether a user is the owner of the entity.
		/// </summary>
		/// <param name="userID">The ID of the user.</param>
		public bool IsOwnedBy(long userID) => this.OwningUsers.Any(u => u.ID == userID);

		/// <summary>
		/// Test whether a user is the owner of the entity.
		/// </summary>
		/// <param name="user">The user.</param>
		public bool IsOwnedBy(U user) => this.OwningUsers.Contains(user);

		#endregion
	}
}

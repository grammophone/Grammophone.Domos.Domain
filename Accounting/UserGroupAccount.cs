using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// Account which belongs to a group of users.
	/// At least when querying for lists of accounts of this type, 
	/// please remember to early fetch the <see cref="OwningUsers"/> 
	/// property to avoid a 'n+1' performance hit.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	public class UserGroupAccount<U> : Account<U>, IUserGroupTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private UserGroupTrackingTrait<U> userGroupTrackingTrait;

		#endregion

		#region Relations

		/// <summary>
		/// The owners of the account. 
		/// At least when querying for lists of accounts of this type, 
		/// please remember to early fetch the owners to avoid a 'n+1' performance hit.
		/// </summary>
		[IgnoreDataMember]
		public ICollection<U> OwningUsers
		{
			get
			{
				return userGroupTrackingTrait.OwningUsers;
			}
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	[Serializable]
	public abstract class UserGroupTrackingEntity<U>
		where U : User
	{
	}
}

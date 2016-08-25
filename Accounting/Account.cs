using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// Base for account entities.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class Account<U> : TrackingEntity<U>, IAccount
		where U : User
	{
		#region Primitive properties

		/// <summary>
		/// Primary key.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// The balance of the account.
		/// </summary>
		public virtual decimal Balance { get; set; }

		#endregion
	}
}

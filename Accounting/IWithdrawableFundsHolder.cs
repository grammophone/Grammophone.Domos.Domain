using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Contract of an account system from which amounts can be withdrawn.
	/// </summary>
	/// <typeparam name="U">The type of users, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="A">The base type of accounts, derived from <see cref="Account{U}"/>.</typeparam>
	public interface IWithdrawableFundsHolder<U, A>
		where U : User
		where A : Account<U>
	{
		/// <summary>
		/// The main account.
		/// </summary>
		A MainAccount { get; }

		/// <summary>
		/// Account holding the outgoing funds.
		/// </summary>
		A RetainingAccount { get; }
	}
}

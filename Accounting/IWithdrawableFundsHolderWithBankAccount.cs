using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Contract of an account system with banking information
	/// from which amounts can be withdrawn
	/// </summary>
	/// <typeparam name="U">The type of users, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="A">The base type of accounts, derived from <see cref="Account{U}"/>.</typeparam>
	public interface IWithdrawableFundsHolderWithBankAccount<U, A> 
		: IWithdrawableFundsHolder<U, A>
		where U : User
		where A : Account<U>
	{
		/// <summary>
		/// The banking information.
		/// </summary>
		IBankAccountHolder BankingDetail { get; }
	}
}

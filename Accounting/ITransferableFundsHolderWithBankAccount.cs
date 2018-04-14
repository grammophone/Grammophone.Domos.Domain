using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Contract of an account system with banking information
	/// from which amounts can be transfered.
	/// </summary>
	public interface ITransferableFundsHolderWithBankAccount
		: ITransferableFundsHolder
	{
		/// <summary>
		/// The banking information.
		/// </summary>
		IBankingDetail BankingDetail { get; }
	}
}

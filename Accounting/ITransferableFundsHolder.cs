using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Contract of an account system from which amounts can be transfered.
	/// </summary>
	public interface ITransferableFundsHolder
	{
		/// <summary>
		/// The main account.
		/// </summary>
		Account MainAccount { get; }

		/// <summary>
		/// Account holding the outgoing funds.
		/// </summary>
		Account TransferAccount { get; }
	}
}

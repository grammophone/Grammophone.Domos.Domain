using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Interface implemented by entities having
	/// an <see cref="EncryptedBankAccountInfo"/> property.
	/// </summary>
	public interface IBankAccountHolder
	{
		/// <summary>
		/// The encrypted bank account.
		/// </summary>
		EncryptedBankAccountInfo EncryptedBankAccountInfo { get; set; }

		/// <summary>
		/// Get the name of the holder of the bank account.
		/// </summary>
		string GetBankAccountHolderName();
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Embeddable record for the encrypted specification of a bank account.
	/// </summary>
	[Serializable]
	public class EncryptedBankAccountInfo
	{
		#region Public properties

		/// <summary>
		/// The encrypted account number.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual byte[] EncryptedAccountNumber { get; set; }

		/// <summary>
		/// The bank number, used in Canada.
		/// </summary>
		[MaxLength(6)]
		public virtual string BankNumber { get; set; }

		/// <summary>
		/// The encrypted transit number, specified in the cheque.
		/// </summary>
		[MaxLength(32)]
		public virtual byte[] EncryptedTransitNumber { get; set; }

		/// <summary>
		/// Account code, used in United states.
		/// </summary>
		[MaxLength(6)]
		public virtual string AccountCode { get; set; }

		/// <summary>
		/// Optional type, when the system supports many bank account
		/// formats at the same time.
		/// </summary>
		[MaxLength(12)]
		public virtual string Type { get; set; }

		#endregion
	}
}

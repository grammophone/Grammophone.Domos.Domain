using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Represents an Electronic Funds Transfer (EFT/ACH) request.
	/// </summary>
	[Serializable]
	public class FundsTransferRequest : EntityWithID<long>
	{
		#region Private fields

		private EncryptedBankAccountInfo bankAccountInfo;

		private ICollection<FundsTransferEvent> events;

		#endregion

		#region Primitive properties

		/// <summary>
		/// If positive, The amount is deposited to the bank account specified
		/// by <see cref="EncryptedBankAccountInfo"/>, else it is withdrawed.
		/// </summary>
		public virtual decimal Amount { get; set; }

		/// <summary>
		/// The state of this transfer request.
		/// </summary>
		public virtual FundsTransferState State { get; set; }

		/// <summary>
		/// The ID of the external system transaction.
		/// </summary>
		[Required]
		[MaxLength(225)]
		public virtual string TransactionID { get; set; }

		/// <summary>
		/// Optional ID of the batch, when the transfer is part of a batch.
		/// </summary>
		[MaxLength(225)]
		public virtual string BatchID { get; set; }

		/// <summary>
		/// Optional comments.
		/// </summary>
		[MaxLength(256)]
		public virtual string Comments { get; set; }

		/// <summary>
		/// The encrypted bank account from which the <see cref="Amount"/> is withdrawn, if negative,
		/// or deposited, if positive.
		/// This is an embedded entity, not a relation.
		/// </summary>
		public virtual EncryptedBankAccountInfo EncryptedBankAccountInfo
		{
			get
			{
				return bankAccountInfo ?? (bankAccountInfo = new EncryptedBankAccountInfo());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				bankAccountInfo = value;
			}
		}

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the credit provider for the funds transfer.
		/// </summary>
		public virtual long CreditSystemID { get; set; }

		/// <summary>
		/// The credit provider for the funds transfer.
		/// </summary>
		public virtual CreditSystem CreditSystem { get; set; }

		/// <summary>
		/// The events recorded for this request.
		/// </summary>
		public virtual ICollection<FundsTransferEvent> Events
		{
			get
			{
				return events ?? (events = new HashSet<FundsTransferEvent>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				events = value;
			}
		}

		#endregion
	}
}

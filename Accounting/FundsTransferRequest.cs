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
	public class FundsTransferRequest : TrackingEntityWithID<User, long>
	{
		#region Constants

		/// <summary>
		/// The maximum length of the <see cref="TransactionID"/> property.
		/// </summary>
		public const int TransactionIdLength = 225;

		/// <summary>
		/// The maximum length of the <see cref="Comments"/> property.
		/// </summary>
		public const int CommentsLength = 256;

		#endregion

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
		[MaxLength(TransactionIdLength)]
		public virtual string TransactionID { get; set; }

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
		/// The ID of the account on which the <see cref="Amount"/> is charged.
		/// </summary>
		public virtual long MainAccountID { get; set; }

		/// <summary>
		/// The account on which the <see cref="Amount"/> is charged.
		/// </summary>
		public virtual Account MainAccount { get; set; }

		/// <summary>
		/// If the <see cref="Amount"/> is positive, this is the 
		/// ID of the account which collects the <see cref="Amount"/> under transfer
		/// when an event of type <see cref="FundsTransferEventType.Failed"/>
		/// is received. It can point to the same account as <see cref="MainAccount"/>.
		/// </summary>
		public virtual long? ErrorAccountID { get; set; }

		/// <summary>
		/// If the <see cref="Amount"/> is positive, this is the 
		/// account collects the <see cref="Amount"/> under transfer
		/// when an event of type <see cref="FundsTransferEventType.Failed"/>
		/// is received. It can point to the same account as <see cref="MainAccount"/>.
		/// </summary>
		public virtual Account ErrorAccount { get; set; }

		/// <summary>
		/// If the <see cref="Amount"/> is positive, this is the 
		/// ID of the account which holds the <see cref="Amount"/> under transfer temporarily
		/// until an event of type <see cref="FundsTransferEventType.Succeeded"/>
		/// or <see cref="FundsTransferEventType.Failed"/> is received.
		/// </summary>
		public virtual long? EscrowAccountID { get; set; }

		/// <summary>
		/// If the <see cref="Amount"/> is positive, this is the 
		/// account which holds the <see cref="Amount"/> under transfer temporarily
		/// until an event of type <see cref="FundsTransferEventType.Succeeded"/>
		/// or <see cref="FundsTransferEventType.Failed"/> is received.
		/// </summary>
		public virtual Account EscrowAccount { get; set; }

		/// <summary>
		/// Optional ID of the batch, when the transfer is part of one.
		/// </summary>
		public virtual Guid? BatchID { get; set; }

		/// <summary>
		/// Optional batch, when the transfer is part of one.
		/// </summary>
		public virtual FundsTransferRequestBatch Batch { get; set; }

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

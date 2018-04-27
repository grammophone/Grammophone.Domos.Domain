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
		/// The maximum length of the <see cref="Comments"/> property.
		/// </summary>
		public const int CommentsLength = 256;

		#endregion

		#region Private fields

		private ICollection<FundsTransferEvent> events;

		#endregion

		#region Primitive properties

		/// <summary>
		/// If positive, The amount is deposited to the bank account specified
		/// by <see cref="EncryptedBankAccountInfo"/>, else it is withdrawed.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferRequestResources),
			Name = nameof(FundsTransferRequestResources.Amount_Name))]
		public virtual decimal Amount { get; set; }

		/// <summary>
		/// The ID of the external system transaction.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferRequestResources),
			Name = nameof(FundsTransferRequestResources.GUID_Name))]
		public virtual Guid GUID { get; set; }

		/// <summary>
		/// Optional comments.
		/// </summary>
		[MaxLength(CommentsLength)]
		[DataType(DataType.MultilineText)]
		[Display(
			ResourceType = typeof(FundsTransferRequestResources),
			Name = nameof(FundsTransferRequestResources.Comments_Name))]
		public virtual string Comments { get; set; }

		#endregion

		#region Relations

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
		public virtual long? TransferAccountID { get; set; }

		/// <summary>
		/// If the <see cref="Amount"/> is positive, this is the 
		/// account which holds the <see cref="Amount"/> under transfer temporarily
		/// until an event of type <see cref="FundsTransferEventType.Succeeded"/>
		/// or <see cref="FundsTransferEventType.Failed"/> is received.
		/// </summary>
		public virtual Account TransferAccount { get; set; }

		/// <summary>
		/// Optional ID of the batch, when the transfer is part of one.
		/// </summary>
		public virtual long? BatchID { get; set; }

		/// <summary>
		/// Optional batch, when the transfer is part of one.
		/// </summary>
		public virtual FundsTransferBatch Batch { get; set; }

		/// <summary>
		/// The ID of the group with common banking info where the request belongs.
		/// </summary>
		public virtual long GroupID { get; set; }

		/// <summary>
		/// The group with common banking info where the request belongs.
		/// </summary>
		public virtual FundsTransferRequestGroup Group { get; set; }

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

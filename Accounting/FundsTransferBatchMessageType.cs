using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Type of a <see cref="FundsTransferBatchMessage"/>.
	/// </summary>
	public enum FundsTransferBatchMessageType
	{
		/// <summary>
		/// Ther batch is pending to be submitted.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferBatchMessageTypeResources),
			Name = nameof(FundsTransferBatchMessageTypeResources.Pending_Name))]
		Pending = 0,

		/// <summary>
		/// The batch has been submitted.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferBatchMessageTypeResources),
			Name = nameof(FundsTransferBatchMessageTypeResources.Submitted_Name))]
		Submitted = 1,

		/// <summary>
		/// The batch was found invalid and was rejected by the credit system.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferBatchMessageTypeResources),
			Name = nameof(FundsTransferBatchMessageTypeResources.Rejected_Name))]
		Rejected = 2,

		/// <summary>
		/// The batch has been accepted by the credit system.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferBatchMessageTypeResources),
			Name = nameof(FundsTransferBatchMessageTypeResources.Accepted_Name))]
		Accepted = 3,

		/// <summary>
		/// A response for the batch has been received from the credit system.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferBatchMessageTypeResources),
			Name = nameof(FundsTransferBatchMessageTypeResources.Responded_Name))]
		Responded = 4
	}
}

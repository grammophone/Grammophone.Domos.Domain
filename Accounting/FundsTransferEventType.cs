using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Type of a <see cref="FundsTransferEvent"/>.
	/// </summary>
	public enum FundsTransferEventType
	{
		/// <summary>
		/// The transfer is pending queued for submission.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventTypeResources),
			Name = nameof(FundsTransferEventTypeResources.Pending_Name))]
		Pending = 0,

		/// <summary>
		/// The transfer has been submitted to the EFT/ACH system
		/// but has not yet succeeded or failed.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventTypeResources),
			Name = nameof(FundsTransferEventTypeResources.Submitted_Name))]
		Submitted = 1,

		/// <summary>
		/// The transfer has been accepted by the EFT/ACH system
		/// but has not yet succeeded or failed.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventTypeResources),
			Name = nameof(FundsTransferEventTypeResources.Accepted_Name))]
		Accepted = 2,

		/// <summary>
		/// The transfer has failed.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventTypeResources),
			Name = nameof(FundsTransferEventTypeResources.Failed_Name))]
		Failed = 3,

		/// <summary>
		/// The funds transfer has succeeded from the credit source but the associated workflow action
		/// has failed.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventTypeResources),
			Name = nameof(FundsTransferEventTypeResources.WorkflowFailed_Name))]
		WorkflowFailed = 4,

		/// <summary>
		/// The transfer has been successful.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventTypeResources),
			Name = nameof(FundsTransferEventTypeResources.Succeeded_Name))]
		Succeeded = 5
	}
}

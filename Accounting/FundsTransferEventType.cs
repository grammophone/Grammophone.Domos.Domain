using System;
using System.Collections.Generic;
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
		Pending = 0,

		/// <summary>
		/// The transfer has been submitted to the EFT/ACH system
		/// but has not yet succeeded or failed.
		/// </summary>
		Submitted = 1,

		/// <summary>
		/// The transfer has been accepted by the EFT/ACH system
		/// but has not yet succeeded or failed.
		/// </summary>
		Accepted = 2,

		/// <summary>
		/// The transfer has failed.
		/// </summary>
		Failed = 3,

		/// <summary>
		/// The transfer has been successful.
		/// </summary>
		Succeeded = 4,

		/// <summary>
		/// The funds transfer has succeeded from the credit source but the associated workflow action
		/// has failed.
		/// </summary>
		WorkflowFailed = 5
	}
}

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
		/// The transfer has been queued for submission.
		/// </summary>
		Queued = 0,

		/// <summary>
		/// The transfer has failed.
		/// </summary>
		Failed = 1,

		/// <summary>
		/// The transfer has been submitted to the EFT/ACH system
		/// but has not yet succeeded or failed.
		/// </summary>
		Submitted = 2,

		/// <summary>
		/// The transfer has been accepted by the EFT/ACH system
		/// but has not yet succeeded or failed.
		/// </summary>
		Accepted = 3,

		/// <summary>
		/// The transfer has been successful.
		/// </summary>
		Succeeded = 4,

		/// <summary>
		/// The transfer has been successful but the workflow action associatged with it has failed.
		/// </summary>
		WorkflowFailed
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// State of a <see cref="FundsTransferRequest"/>.
	/// </summary>
	public enum FundsTransferState
	{
		/// <summary>
		/// The transfer is pending to be sent to the EFT/ACH system.
		/// </summary>
		Pending = 0,

		/// <summary>
		/// The transfer has failed.
		/// </summary>
		Failed = 1,

		/// <summary>
		/// The transfer has been submitted to the EFT/ACH system.
		/// </summary>
		Submitted = 2,

		/// <summary>
		/// The transfer has been successful.
		/// </summary>
		Succeeded = 3,

		/// <summary>
		/// The transfer has been successful but the workflow action associated with it has failed.
		/// </summary>
		WorkflowFailed = 4
	}
}

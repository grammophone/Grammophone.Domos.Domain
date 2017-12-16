using System;
using System.Collections.Generic;
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
		Pending = 0,

		/// <summary>
		/// The batch has been submitted.
		/// </summary>
		Submitted = 1,

		/// <summary>
		/// The batch was found invalid and was rejected by the credit system.
		/// </summary>
		Rejected = 2,

		/// <summary>
		/// The batch has been accepted by the credit system.
		/// </summary>
		Accepted = 3,

		/// <summary>
		/// A response for the batch has been received from the credit system.
		/// </summary>
		Responded = 4
	}
}

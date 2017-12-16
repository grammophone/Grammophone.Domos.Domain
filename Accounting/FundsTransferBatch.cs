using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Optional batch grouping for <see cref="FundsTransferRequest"/>s.
	/// </summary>
	[Serializable]
	public class FundsTransferBatch : TrackingEntityWithID<User, Guid>
	{
		#region Private fields

		private ICollection<FundsTransferRequest> requests;

		private ICollection<FundsTransferBatchMessage> messages;

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the credit system which processes the batch.
		/// </summary>
		public virtual long CreditSystemID { get; set; }

		/// <summary>
		/// The credit system which processes the batch.
		/// </summary>
		public virtual CreditSystem CreditSystem { get; set; }

		/// <summary>
		/// The funds transfer requests contained in this batch.
		/// </summary>
		public virtual ICollection<FundsTransferRequest> Requests
		{
			get
			{
				return requests ?? (requests = new HashSet<FundsTransferRequest>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				requests = value;
			}
		}

		/// <summary>
		/// The events making the histoery of this batch.
		/// </summary>
		public virtual ICollection<FundsTransferBatchMessage> Messages
		{
			get
			{
				return messages ?? (messages = new HashSet<FundsTransferBatchMessage>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				messages = value;
			}
		}

		#endregion
	}
}

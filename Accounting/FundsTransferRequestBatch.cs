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
	public class FundsTransferRequestBatch : TrackingEntityWithID<User, Guid>
	{
		#region Private fields

		private ICollection<FundsTransferRequest> requests;

		#endregion

		#region Relations

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

		#endregion
	}
}

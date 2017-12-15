using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// An event in the history of a <see cref="FundsTransferBatch"/>.
	/// </summary>
	[Serializable]
	public class FundsTransferBatchEvent : TrackingEntityWithID<User, long>
	{
		#region Public properties

		/// <summary>
		/// The type of the event.
		/// </summary>
		public virtual FundsTransferBatchEventType Type { get; set; }

		/// <summary>
		/// The date and time of the event, in UTC.
		/// </summary>
		public virtual DateTime Time { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the funds transfer batch where this event belongs.
		/// </summary>
		public virtual Guid BatchID { get; set; }

		/// <summary>
		/// The funds transfer batch where this event belongs.
		/// </summary>
		public virtual FundsTransferBatch Batch { get; set; }

		#endregion
	}
}

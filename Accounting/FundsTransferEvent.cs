using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Represents the events taking place 
	/// for a <see cref="FundsTransferRequest"/>.
	/// </summary>
	[Serializable]
	public class FundsTransferEvent : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// The response code as returned by the Electronic Funds
		/// Transfer (EFT/ACH) system.
		/// </summary>
		[MaxLength(3)]
		public virtual string ResponseCode { get; set; }

		/// <summary>
		/// The UTC date and time of the event.
		/// </summary>
		public virtual DateTime Date { get; set; }

		/// <summary>
		/// Unique code for event tracing.
		/// </summary>
		[MaxLength(36)]
		public virtual string TraceCode { get; set; }

		/// <summary>
		/// The type of this transfer event.
		/// </summary>
		public virtual FundsTransferEventType Type { get; set; }

		/// <summary>
		/// Optional comments.
		/// </summary>
		[MaxLength(256)]
		public virtual string Comments { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the request.
		/// </summary>
		public virtual long RequestID { get; set; }

		/// <summary>
		/// The request.
		/// </summary>
		public virtual FundsTransferRequest Request { get; set; }

		#endregion
	}
}

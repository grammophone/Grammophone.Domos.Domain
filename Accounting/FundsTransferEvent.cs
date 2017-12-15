﻿using System;
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
	public class FundsTransferEvent : TrackingEntityWithID<User, long>
	{
		#region Constants

		/// <summary>
		/// The maximum length of the <see cref="ResponseCode"/> property.
		/// </summary>
		public const int ResponseCodeLength = 3;

		/// <summary>
		/// The maximum length of the <see cref="TraceCode"/> property.
		/// </summary>
		public const int TraceCodeLength = 36;

		/// <summary>
		/// The maximum length of the <see cref="Comments"/> property.
		/// </summary>
		public const int CommentsLength = 512;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The response code as returned by the Electronic Funds
		/// Transfer (EFT/ACH) system.
		/// </summary>
		[MaxLength(ResponseCodeLength)]
		public virtual string ResponseCode { get; set; }

		/// <summary>
		/// The UTC date and time of the event.
		/// </summary>
		public virtual DateTime Time { get; set; }

		/// <summary>
		/// Unique code for event tracing.
		/// </summary>
		[MaxLength(TraceCodeLength)]
		public virtual string TraceCode { get; set; }

		/// <summary>
		/// The type of this transfer event.
		/// </summary>
		public virtual FundsTransferEventType Type { get; set; }

		/// <summary>
		/// Optional comments.
		/// </summary>
		[MaxLength(CommentsLength)]
		public virtual string Comments { get; set; }

		/// <summary>
		/// Optional serialized exception. This is set when <see cref="Type"/>
		/// is <see cref="FundsTransferEventType.WorkflowFailed"/>.
		/// </summary>
		public virtual byte[] ExceptionData { get; set; }

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

		/// <summary>
		/// Optional ID of the collation where the event belongs.
		/// </summary>
		public virtual Guid? CollationID { get; set; }

		/// <summary>
		/// Optional collation where the event belongs.
		/// </summary>
		public virtual FundsTransferEventCollation Collation { get; set; }

		#endregion
	}
}

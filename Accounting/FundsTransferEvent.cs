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
		[Display(
			ResourceType = typeof(FundsTransferEventResources),
			Name = nameof(FundsTransferEventResources.ResponseCode_Name),
			Description = nameof(FundsTransferEventResources.ResponseCode_Description))]
		public virtual string ResponseCode { get; set; }

		/// <summary>
		/// The UTC date and time of the event.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventResources),
			Name = nameof(FundsTransferEventResources.Time_Name),
			Description = nameof(FundsTransferEventResources.Time_Description))]
		public virtual DateTime Time { get; set; }

		/// <summary>
		/// Unique code for event tracing.
		/// </summary>
		[MaxLength(TraceCodeLength)]
		[Display(
			ResourceType = typeof(FundsTransferEventResources),
			Name = nameof(FundsTransferEventResources.TraceCode_Name),
			Description = nameof(FundsTransferEventResources.TraceCode_Description))]
		public virtual string TraceCode { get; set; }

		/// <summary>
		/// The type of the transfer event.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventResources),
			Name = nameof(FundsTransferEventResources.Type_Name),
			Description = nameof(FundsTransferEventResources.Type_Description))]
		public virtual FundsTransferEventType Type { get; set; }

		/// <summary>
		/// Optional comments for the event.
		/// </summary>
		[MaxLength(CommentsLength)]
		[DataType(DataType.MultilineText)]
		[Display(
			ResourceType = typeof(FundsTransferEventResources),
			Name = nameof(FundsTransferEventResources.Comments_Name),
			Description = nameof(FundsTransferEventResources.Comments_Description))]
		public virtual string Comments { get; set; }

		/// <summary>
		/// Optional serialized exception. This is set when the digestion of a response from the EFT/ACH system failed.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventResources),
			Name = nameof(FundsTransferEventResources.ExceptionData_Name),
			Description = nameof(FundsTransferEventResources.ExceptionData_Description))]
		public virtual byte[] ExceptionData { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the request.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventResources),
			Name = nameof(FundsTransferEventResources.RequestID_Name))]
		public virtual long RequestID { get; set; }

		/// <summary>
		/// The request.
		/// </summary>
		public virtual FundsTransferRequest Request { get; set; }

		/// <summary>
		/// Optional ID of the collation where the event belongs.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferEventResources),
			Name = nameof(FundsTransferEventResources.BatchMessageID_Name))]
		public virtual long? BatchMessageID { get; set; }

		/// <summary>
		/// Optional collation where the event belongs.
		/// </summary>
		public virtual FundsTransferBatchMessage BatchMessage { get; set; }

		#endregion
	}
}

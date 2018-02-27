using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// An event in the history of a <see cref="FundsTransferBatch"/>.
	/// </summary>
	[Serializable]
	public class FundsTransferBatchMessage : TrackingEntityWithID<User, Guid>
	{
		#region Constants

		/// <summary>
		/// The maximum length of the <see cref="MessageCode"/> property.
		/// </summary>
		public const int MessageCodeLength = 16;

		/// <summary>
		/// The maximum length of the <see cref="Comments"/> property.
		/// </summary>
		public const int CommentsLength = 512;

		#endregion

		#region Private fields

		private ICollection<FundsTransferEvent> events;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The type of the event.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferBatchMessageResources),
			Name = nameof(FundsTransferBatchMessageResources.Type_Name))]
		public virtual FundsTransferBatchMessageType Type { get; set; }

		/// <summary>
		/// The date and time of the event, in UTC.
		/// </summary>
		[DataType(DataType.DateTime)]
		[Display(
			ResourceType = typeof(FundsTransferBatchMessageResources),
			Name = nameof(FundsTransferBatchMessageResources.Time_Name))]
		public virtual DateTime Time { get; set; }

		/// <summary>
		/// Optional code for the message. Maximum length is <see cref="MessageCodeLength"/>.
		/// </summary>
		[MaxLength(MessageCodeLength)]
		[Display(
			ResourceType = typeof(FundsTransferBatchMessageResources),
			Name = nameof(FundsTransferBatchMessageResources.MessageCode_Name))]
		public virtual string MessageCode { get; set; }

		/// <summary>
		/// Optional comments for the message. Maximum length is <see cref="CommentsLength"/>.
		/// </summary>
		[MaxLength(CommentsLength)]
		[DataType(DataType.MultilineText)]
		[Display(
			ResourceType = typeof(FundsTransferBatchMessageResources),
			Name = nameof(FundsTransferBatchMessageResources.Comments_Name))]
		public virtual string Comments { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the funds transfer batch where this event belongs.
		/// </summary>
		public virtual long BatchID { get; set; }

		/// <summary>
		/// The funds transfer batch where this event belongs.
		/// </summary>
		public virtual FundsTransferBatch Batch { get; set; }

		/// <summary>
		/// The funds transfer events 
		/// </summary>
		public virtual ICollection<FundsTransferEvent> Events
		{
			get
			{
				return events ?? (events = new HashSet<FundsTransferEvent>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				events = value;
			}
		}

		#endregion
	}
}

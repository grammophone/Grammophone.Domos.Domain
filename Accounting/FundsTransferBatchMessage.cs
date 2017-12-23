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
		#region Private fields

		private ICollection<FundsTransferEvent> events;

		#endregion

		#region Public properties

		/// <summary>
		/// The type of the event.
		/// </summary>
		[Display(
			ResourceType = typeof(FundsTransferBatchMessage),
			Name = nameof(FundsTransferBatchMessageResources.Type_Name))]
		public virtual FundsTransferBatchMessageType Type { get; set; }

		/// <summary>
		/// The date and time of the event, in UTC.
		/// </summary>
		[DataType(DataType.DateTime)]
		[Display(
			ResourceType = typeof(FundsTransferBatchMessage),
			Name = nameof(FundsTransferBatchMessageResources.Time_Name))]
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Optional collaction of <see cref="FundsTransferEvent"/>s.
	/// </summary>
	[Serializable]
	public class FundsTransferEventCollation : TrackingEntityWithID<User, Guid>
	{
		#region Private fields

		private ICollection<FundsTransferEvent> events;

		#endregion

		#region Relations

		/// <summary>
		/// The funds transfer events grouped in this collation.
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

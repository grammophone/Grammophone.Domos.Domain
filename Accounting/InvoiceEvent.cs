using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Records an event which changes the state of an invoice.
	/// </summary>
	/// <typeparam name="U">The type of users, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="P">The type of postings, derived from <see cref="Posting{U}"/>.</typeparam>
	/// <typeparam name="R">the type of remittances, derived from <see cref="Remittance{U}"/>.</typeparam>
	[Serializable]
	public abstract class InvoiceEvent<U, P, R> : TrackingEntityWithID<U, long>
		where U : User
		where P : Posting<U>
		where R : Remittance<U>
	{
		#region Primitive properties

		/// <summary>
		/// Date and time of the event, in UTC.
		/// </summary>
		public virtual DateTime Time { get; set; }

		/// <summary>
		/// The state of the invoice as changed by the event.
		/// </summary>
		public virtual InvoiceState InvoiceState { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the invoice which the event refers to.
		/// </summary>
		public virtual long InvoiceID { get; set; }

		/// <summary>
		/// Optional ID of the posting related to the invoice event.
		/// </summary>
		public virtual long? PostingID { get; set; }

		/// <summary>
		/// Optional posting related to the invoice event.
		/// </summary>
		public virtual P Posting { get; set; }

		/// <summary>
		/// Optional ID of the remittance related to the invoice event.
		/// </summary>
		public virtual long? RemittanceID { get; set; }

		/// <summary>
		/// Optional remittance related to the invoice event.
		/// </summary>
		public virtual R Remittance { get; set; }

		#endregion
	}
}

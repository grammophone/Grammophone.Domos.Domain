using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Abstract base for invoices.
	/// </summary>
	/// <typeparam name="U">The type of users, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="P">The type of postings, derived from <see cref="Posting{U}"/>.</typeparam>
	/// <typeparam name="R">the type of remittances, derived from <see cref="Remittance{U}"/>.</typeparam>
	/// <typeparam name="ILTC">The type of the invoice lines taxes, derived from <see cref="InvoiceLineTaxComponent{U, P, R}"/>.</typeparam>
	/// <typeparam name="IL">The type of the invoice lines, derived from <see cref="InvoiceLine{U, P, R, ILT}"/>.</typeparam>
	/// <typeparam name="IE">The type of the invoce events, derived from <see cref="InvoiceEvent{U, P, R}"/>.</typeparam>
	[Serializable]
	public abstract class Invoice<U, P, R, ILTC, IL, IE> : TrackingEntityWithID<U, long>
		where U : User
		where P : Posting<U>
		where R : Remittance<U>
		where ILTC : InvoiceLineTaxComponent<U, P, R>
		where IL : InvoiceLine<U, P, R, ILTC>
		where IE : InvoiceEvent<U, P, R>
	{
		#region Private fields

		private ICollection<IL> lines;

		private ICollection<IE> events;

		private ICollection<FundsTransferRequest> servicingFundsTransferRequests;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The date when the invoice was issued.
		/// </summary>
		/// <remarks>
		/// Whether this includes time or is defined in UTC, depends on the application.
		/// </remarks>
		[Display(
			ResourceType = typeof(InvoiceResources),
			Name = nameof(InvoiceResources.IssueDate_Name),
			Description = nameof(InvoiceResources.IssueDate_Description))]
		public virtual DateTime IssueDate { get; set; }

		/// <summary>
		/// Optional date when the invoice is due.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceResources),
			Name = nameof(InvoiceResources.DueDate_Name),
			Description = nameof(InvoiceResources.DueDate_Description))]
		public virtual DateTime? DueDate { get; set; }

		/// <summary>
		/// The form of the invoice.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceResources),
			Name = nameof(InvoiceResources.Form_Name),
			Description = nameof(InvoiceResources.Form_Description))]
		public virtual InvoiceForm Form { get; set; }

		/// <summary>
		/// The type of the invoice, either normal charging from seller to customer or reverse from customer to seller.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceResources),
			Name = nameof(InvoiceResources.Type_Name),
			Description = nameof(InvoiceResources.Type_Description))]
		public virtual InvoiceType Type { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The lines contained in the invoice.
		/// </summary>
		public virtual ICollection<IL> Lines
		{
			get
			{
				return lines ?? (lines = new HashSet<IL>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				lines = value;
			}
		}

		/// <summary>
		/// Events recording the hostory of the invoice.
		/// </summary>
		public virtual ICollection<IE> Events
		{
			get
			{
				return events ?? (events = new HashSet<IE>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				events = value;
			}
		}

		/// <summary>
		/// The funds transfer requests which may have been assigned to pay this invoice.
		/// </summary>
		public virtual ICollection<FundsTransferRequest> ServicingFundsTransferRequests
		{
			get
			{
				return servicingFundsTransferRequests ?? (servicingFundsTransferRequests = new HashSet<FundsTransferRequest>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				servicingFundsTransferRequests = value;
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Get the gross amount of the invoice including taxes.
		/// </summary>
		public decimal GetGrossTotal()
			=> this.Lines.Sum(l => l.GetGrossAmount());

		#endregion
	}
}

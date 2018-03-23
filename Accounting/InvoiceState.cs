using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// State of an <see cref="Invoice{U, P, R, ILT, IL, IE}"/>, as recorded
	/// in a <see cref="InvoiceEvent{U, P, R}"/>.
	/// </summary>
	public enum InvoiceState
	{
		/// <summary>
		/// The invoice is still under formation.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceStateResources),
			Name = nameof(InvoiceStateResources.Open_Name))]
		Open = 0,

		/// <summary>
		/// A requirement for a collaboration or transaction to proceed is submitted.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceStateResources),
			Name = nameof(InvoiceStateResources.ProFormaSubmitted_Name))]
		ProFormaSubmitted = 100,

		/// <summary>
		/// A requirement for a collaboration or transaction to proceed is rejected.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceStateResources),
			Name = nameof(InvoiceStateResources.ProFormaRejected_Name))]
		ProFormaRejected = 110,

		/// <summary>
		/// The invoice is registered as payable by the buyer but not yet paid.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceStateResources),
			Name = nameof(InvoiceStateResources.Payable_Name))]
		Payable = 200,

		/// <summary>
		/// The invoice has been partially paid by the buyer.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceStateResources),
			Name = nameof(InvoiceStateResources.PartiallyPaid_Name))]
		PartiallyPaid = 300,

		/// <summary>
		/// The invoice as been fully paid by the buyer.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceStateResources),
			Name = nameof(InvoiceStateResources.Paid_Name))]
		Paid = 400
	}
}

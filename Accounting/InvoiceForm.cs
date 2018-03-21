using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Form of an <see cref="Invoice{U, P, R, ILT, IL}"/>.
	/// </summary>
	public enum InvoiceForm
	{
		/// <summary>
		/// Normal invoice issued by a seller.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceFormResources),
			Name = nameof(InvoiceFormResources.NormalInvoice_Name))]
		NormalInvoice,

		/// <summary>
		/// Receipt.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceFormResources),
			Name = nameof(InvoiceFormResources.Receeipt_Name))]
		Receipt,

		/// <summary>
		/// A debit or credit note issued by a buyer or seller.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceFormResources),
			Name = nameof(InvoiceFormResources.NormalInvoice_Name))]
		Statement
	}
}

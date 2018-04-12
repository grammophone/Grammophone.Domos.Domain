using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Type of an <see cref="Invoice{U, P, R, ILTC, IL, IE}"/>.
	/// </summary>
	public enum InvoiceType
	{
		/// <summary>
		/// Normal charge from seller to customer.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceTypeResources),
			Name = nameof(InvoiceTypeResources.NormalCharge_Name))]
		NormalCharge,

		/// <summary>
		/// Back charge from customer to seller.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceTypeResources),
			Name = nameof(InvoiceTypeResources.ReverseCharge_Name))]
		ReverseCharge
	}
}

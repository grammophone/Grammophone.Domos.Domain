using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Abstract base for a tax component of an invoice line.
	/// </summary>
	/// <typeparam name="U">The type of users, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="P">The type of postings, derived from <see cref="Posting{U}"/>.</typeparam>
	/// <typeparam name="R">the type of remittances, derived from <see cref="Remittance{U}"/>.</typeparam>
	[Serializable]
	public abstract class InvoiceLineTax<U, P, R>
		where U : User
		where P : Posting<U>
		where R : Remittance<U>
	{
		#region Constants

		/// <summary>
		/// Maximum length of the <see cref="Description"/> property.
		/// </summary>
		public const int DescriptionLength = 32;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The description of the tax.
		/// </summary>
		[Required]
		[MaxLength(DescriptionLength)]
		public virtual string Description { get; set; }

		/// <summary>
		/// The rate of the tax as a percentage.
		/// </summary>
		public virtual decimal? RatePercentFactor { get; set; }

		/// <summary>
		/// The amount charged.
		/// </summary>
		public virtual decimal Amount { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// ID of the invoice line where the tax belongs.
		/// </summary>
		public virtual long LineID { get; set; }

		/// <summary>
		/// Optional ID of the posting related to the tax.
		/// </summary>
		public virtual long? PostingID { get; set; }

		/// <summary>
		/// Optional posting related to the tax.
		/// </summary>
		public virtual P Posting { get; set; }

		/// <summary>
		/// Optional ID of the remittance related to the tax.
		/// </summary>
		public virtual long? RemittanceID { get; set; }

		/// <summary>
		/// Optional remittance related to the tax.
		/// </summary>
		public R Remittance { get; set; }

		#endregion
	}
}

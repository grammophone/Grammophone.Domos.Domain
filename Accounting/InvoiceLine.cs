using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Abstract base for invoice lines.
	/// </summary>
	/// <typeparam name="U">The type of users, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="P">The type of postings, derived from <see cref="Posting{U}"/>.</typeparam>
	/// <typeparam name="R">the type of remittances, derived from <see cref="Remittance{U}"/>.</typeparam>
	/// <typeparam name="ILT">The type of the invoice lines taxes, derived from <see cref="InvoiceLineTax{U, P, R}"/>.</typeparam>
	[Serializable]
	public class InvoiceLine<U, P, R, ILT>
		where U : User
		where P : Posting<U>
		where R : Remittance<U>
		where ILT : InvoiceLineTax<U, P, R>
	{
		#region Constants

		/// <summary>
		/// Maximum length of the <see cref="Description"/> property.
		/// </summary>
		public const int DescriptionLength = 384;

		#endregion

		#region Private fields

		private ICollection<ILT> taxes; 

		#endregion

		#region Primitive properties

		/// <summary>
		/// The description of the line.
		/// </summary>
		[Required]
		[MaxLength(DescriptionLength)]
		public virtual string Description { get; set; }

		/// <summary>
		/// Optional quantity indicator.
		/// </summary>
		public virtual decimal? Quantity { get; set; }

		/// <summary>
		/// If <see cref="Quantity"/> is specified, this is the rate each unit is charged.
		/// </summary>
		public virtual decimal? Rate { get; set; }

		/// <summary>
		/// The cost of the line, excluding taxes.
		/// </summary>
		public virtual decimal Amount { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The taxes associated with the line.
		/// </summary>
		public virtual ICollection<ILT> Taxes
		{
			get
			{
				return taxes ?? (taxes = new HashSet<ILT>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				taxes = value;
			}
		}

		#endregion
	}
}

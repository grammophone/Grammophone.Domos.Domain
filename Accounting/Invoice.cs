using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammophone.Domos.Domain.Workflow;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Abstract base for invoices.
	/// </summary>
	/// <typeparam name="U">The type of users, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="P">The type of postings, derived from <see cref="Posting{U}"/>.</typeparam>
	/// <typeparam name="R">the type of remittances, derived from <see cref="Remittance{U}"/>.</typeparam>
	/// <typeparam name="ILT">The type of the invoice lines taxes, derived from <see cref="InvoiceLineTax{U, P, R}"/>.</typeparam>
	/// <typeparam name="IL">The type of the invoice lines, derived from <see cref="InvoiceLine{U, P, R, ILT}"/>.</typeparam>
	[Serializable]
	public abstract class Invoice<U, P, R, ILT, IL>
		where U : User
		where P : Posting<U>
		where R : Remittance<U>
		where ILT : InvoiceLineTax<U, P, R>
		where IL : InvoiceLine<U, P, R, ILT>
	{
		#region Constants

		/// <summary>
		/// Maximum length of the <see cref="IssuerName"/> property.
		/// </summary>
		public const int IssuerNameLength = 384;

		#endregion

		#region Private fields

		private ICollection<IL> lines;

		private ICollection<P> payingPostings;

		private ICollection<R> payingRemittances;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The date when the invoice was issues, in UTC.
		/// </summary>
		public virtual DateTime IssueDate { get; set; }

		/// <summary>
		/// Optional date when the issue is due, in UTC.
		/// </summary>
		public virtual DateTime? DueDate { get; set; }

		/// <summary>
		/// The state of the invoice.
		/// </summary>
		public virtual InvoiceState State { get; set; }

		/// <summary>
		/// The form of the invoice.
		/// </summary>
		public virtual InvoiceForm Form { get; set; }

		/// <summary>
		/// Records the name of the issuer at the time of the invoice.
		/// </summary>
		[Required]
		[MaxLength(IssuerNameLength)]
		public virtual string IssuerName { get; set; }

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
		/// Any postings paying this invoice.
		/// </summary>
		public virtual ICollection<P> PayingPostings
		{
			get
			{
				return payingPostings ?? (payingPostings = new HashSet<P>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				payingPostings = value;
			}
		}

		/// <summary>
		/// Any remittances paying this invoice.
		/// </summary>
		public virtual ICollection<R> PayingRemittances
		{
			get
			{
				return payingRemittances ?? (payingRemittances = new HashSet<R>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				payingRemittances = value;
			}
		}

		#endregion
	}
}

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
	public abstract class Invoice<U, P, R, ILT, IL> : TrackingEntityWithID<U, long>
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

		/// <summary>
		/// Maximum length of the <see cref="IssuerStreet"/> property.
		/// </summary>
		public const int IssuerStreetLength = 256;

		/// <summary>
		/// Maximum length of the <see cref="IssuerCity"/> property.
		/// </summary>
		public const int IssuerCityLength = 128;

		/// <summary>
		/// Maximum length of the <see cref="IssuerPostalCode"/> property.
		/// </summary>
		public const int IssuerPostalCodeLength = 32;

		/// <summary>
		/// Maximum length of the <see cref="IssuerProvince"/> property.
		/// </summary>
		public const int IssuerProvinceLength = 96;

		/// <summary>
		/// Maximum length of the <see cref="IssuerCountry"/> property.
		/// </summary>
		public const int IssuerCountryLength = 96;

		/// <summary>
		/// Maximum length of the <see cref="IssuerTaxID"/> property.
		/// </summary>
		public const int IssuerTaxIdLength = 32;

		#endregion

		#region Private fields

		private ICollection<IL> lines;

		private ICollection<P> payingPostings;

		private ICollection<R> payingRemittances;

		private ICollection<FundsTransferRequest> servicingFundsTransferRequests;

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

		/// <summary>
		/// Street and number of the issuer.
		/// </summary>
		[MaxLength(IssuerStreetLength)]
		public virtual string IssuerStreet { get; set; }

		/// <summary>
		/// City of the issuer.
		/// </summary>
		[MaxLength(IssuerCityLength)]
		public virtual string IssuerCity { get; set; }

		/// <summary>
		/// Postal code of the issuer.
		/// </summary>
		[MaxLength(IssuerPostalCodeLength)]
		public virtual string IssuerPostalCode { get; set; }

		/// <summary>
		/// Province of the issuer.
		/// </summary>
		[MaxLength(IssuerProvinceLength)]
		public virtual string IssuerProvince { get; set; }

		/// <summary>
		/// Country of the issuer.
		/// </summary>
		[MaxLength(IssuerCountryLength)]
		public virtual string IssuerCountry { get; set; }

		/// <summary>
		/// Tax ID of the issuer.
		/// </summary>
		[MaxLength(IssuerTaxIdLength)]
		public virtual string IssuerTaxID { get; set; }

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

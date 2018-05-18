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
	/// <typeparam name="ILTC">The type of the invoice lines taxes, derived from <see cref="InvoiceLineTaxComponent{U, P, R}"/>.</typeparam>
	[Serializable]
	public abstract class InvoiceLine<U, P, R, ILTC> : TrackingEntityWithID<U, long>
		where U : User
		where P : Posting<U>
		where R : Remittance<U>
		where ILTC : InvoiceLineTaxComponent<U, P, R>
	{
		#region Constants

		/// <summary>
		/// Maximum length of the <see cref="Description"/> property.
		/// </summary>
		public const int DescriptionLength = 384;

		#endregion

		#region Private fields

		private ICollection<ILTC> taxComponents; 

		#endregion

		#region Primitive properties

		/// <summary>
		/// The description of the line.
		/// </summary>
		[Required]
		[MaxLength(DescriptionLength)]
		[Display(
			ResourceType = typeof(InvoiceLineResources),
			Name = nameof(InvoiceLineResources.Description_Name))]
		public virtual string Description { get; set; }

		/// <summary>
		/// Optional quantity indicator.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceLineResources),
			Name = nameof(InvoiceLineResources.Quantity_Name))]
		public virtual decimal? Quantity { get; set; }

		/// <summary>
		/// If <see cref="Quantity"/> is specified, this is the rate each unit is charged.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceLineResources),
			Name = nameof(InvoiceLineResources.Rate_Name))]
		public virtual decimal? Rate { get; set; }

		/// <summary>
		/// The net cost of the line, excluding taxes.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceLineResources),
			Name = nameof(InvoiceLineResources.Amount_Name))]
		public virtual decimal Amount { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the invoice where the line belongs.
		/// </summary>
		[Display(
			ResourceType = typeof(InvoiceLineResources),
			Name = nameof(InvoiceLineResources.InvoiceID_Name))]
		public virtual long InvoiceID { get; set; }

		/// <summary>
		/// Optional ID of the posting related to the invoice line.
		/// </summary>
		public virtual long? PostingID { get; set; }

		/// <summary>
		/// Optional posting related to the invoice event.
		/// </summary>
		public virtual P Posting { get; set; }

		/// <summary>
		/// Optional ID of the remittance related to the invoice line.
		/// </summary>
		public virtual long? RemittanceID { get; set; }

		/// <summary>
		/// Optional remittance related to the invoice event.
		/// </summary>
		public virtual R Remittance { get; set; }

		/// <summary>
		/// The taxes associated with the line.
		/// </summary>
		public virtual ICollection<ILTC> TaxComponents
		{
			get
			{
				return taxComponents ?? (taxComponents = new HashSet<ILTC>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				taxComponents = value;
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Get the gross amount of the line including taxes.
		/// </summary>
		public decimal GetGrossAmount()
			=> this.Amount + this.TaxComponents.Sum(t => t.Amount);

		#endregion
	}
}

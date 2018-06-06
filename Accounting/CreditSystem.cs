using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// The credit system, which represents a financial institution or a gateway
	/// through which
	/// </summary>
	[Serializable]
	public class CreditSystem : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// The name of the credit system.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[Display(
			ResourceType = typeof(CreditSystemResources),
			Name = nameof(CreditSystemResources.Name_Name),
			Description = nameof(CreditSystemResources.Name_Description))]
		public virtual string Name { get; set; }

		/// <summary>
		/// The unique code name of the credit system.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[Display(
			ResourceType = typeof(CreditSystemResources),
			Name = nameof(CreditSystemResources.CodeName_Name),
			Description = nameof(CreditSystemResources.CodeName_Description))]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// Optional name of a registered funds transfer file converter to be associated
		/// with the credit system
		/// </summary>
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(CreditSystemResources),
			Name = nameof(CreditSystemResources.FundsTransferFileConverterName_Name),
			Description = nameof(CreditSystemResources.FundsTransferFileConverterName_Description))]
		public virtual string FundsTransferFileConverterName { get; set; }

		#endregion
	}
}

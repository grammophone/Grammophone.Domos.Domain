using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// A single-entry accounting record intended to represent
	/// external system inflow or outflow, where a double-entry recording cannot be kept.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public class Remittance<U> : JournalLine<U>
		where U : User
	{
		#region Primitive properties

		/// <summary>
		/// The ID of the external system transaction.
		/// </summary>
		[Required]
		public virtual string TransactionID { get; set; }

		#endregion

		#region Relationships

		/// <summary>
		/// The ID of the credit system through which 
		/// the <see cref="JournalLine{U}.Amount"/> is being transferred.
		/// </summary>
		public virtual long CreditSystemID { get; set; }

		/// <summary>
		/// The credit system through which 
		/// the <see cref="JournalLine{U}.Amount"/> is being transferred.
		/// </summary>
		public virtual CreditSystem CreditSystem { get; set; }

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// A single-entry accounting record, being part of a <see cref="Batch{U}"/>,
	/// intended to represent external system inflow or outflow , 
	/// where a double-entry recording cannot be kept.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class BatchRemittance<U> : JournalLine<U>
		where U : User
	{
		#region Primitive properties

		/// <summary>
		/// The line ID according to the <see cref="Batch"/>
		/// where this remittance belongs.
		/// </summary>
		[Required]
		public virtual string LineID { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID batch where this remittance belongs.
		/// </summary>
		public virtual long BatchID { get; set; }

		/// <summary>
		/// The batch where this remittance belongs.
		/// </summary>
		public virtual Batch Batch { get; set; }

		#endregion
	}
}

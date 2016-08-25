using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// A batch of single-entry accounting records intended to represent
	/// external system inflow or outflow, where a double-entry recording cannot be kept.
	/// </summary>
	[Serializable]
	public class Batch<U> : UserGroupTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private ICollection<BatchRemittance<U>> remittances;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The primary key.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// The ID of the transaction according to the <see cref="CreditSystem"/>.
		/// </summary>
		[Required]
		public virtual string TransactionID { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the external credit system associated with this batch.
		/// </summary>
		public virtual long CreditSystemID { get; set; }

		/// <summary>
		/// The external credit system associated with this batch.
		/// </summary>
		public virtual CreditSystem CreditSystem { get; set; }

		/// <summary>
		/// The remittances belonging to this batch.
		/// </summary>
		public virtual ICollection<BatchRemittance<U>> Remittances
		{
			get
			{
				return remittances ?? (remittances = new HashSet<BatchRemittance<U>>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				remittances = value;
			}
		}

		#endregion
	}
}

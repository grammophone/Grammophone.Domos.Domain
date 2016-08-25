using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// The credit system, which represents a financial institution or a gateway
	/// through which
	/// </summary>
	[Serializable]
	public class CreditSystem
	{
		#region Primitive properties

		/// <summary>
		/// The primary key.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// The name of the credit system.
		/// </summary>
		[Required]
		public virtual string Name { get; set; }

		/// <summary>
		/// The code name of the credit system.
		/// </summary>
		[Required]
		public virtual string Code { get; set; }

		#endregion
	}
}

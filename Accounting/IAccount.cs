using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Contract for an entity representing an account.
	/// </summary>
	public interface IAccount
	{
		/// <summary>
		/// The ID of the account.
		/// </summary>
		long ID { get; set; }

		/// <summary>
		/// The balance of the account.
		/// </summary>
		decimal Balance { get; set; }
	}
}

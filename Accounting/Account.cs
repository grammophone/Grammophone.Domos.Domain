using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Base for account entities.
	/// </summary>
	[Serializable]
	public abstract class Account : EntityWithID<long>, IAccount
	{
		#region Primitive properties

		/// <summary>
		/// The balance of the account.
		/// </summary>
		[Display(
			ResourceType = typeof(AccountResources),
			Name = nameof(AccountResources.Balance_Name),
			Description = nameof(AccountResources.Balance_Description))]
		public virtual decimal Balance { get; set; }

		#endregion
	}
}

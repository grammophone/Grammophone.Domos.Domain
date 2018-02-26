using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Grouping of <see cref="FundsTransferRequest"/>s based on <see cref="EncryptedBankAccountInfo"/>.
	/// WARNING: The members of the group might belong to numerous batches.
	/// In other words, this group is reused when necessary.
	/// </summary>
	[Serializable]
	public class FundsTransferRequestGroup : EntityWithID<long>
	{
		#region Private fields

		private EncryptedBankAccountInfo encryptedBankAccountInfo;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The encrypted baking info common to all funds transfer requests which are members of the
		/// group. This is an embedded property, not a relation.
		/// </summary>
		public virtual EncryptedBankAccountInfo EncryptedBankAccountInfo
		{
			get
			{
				return encryptedBankAccountInfo ?? (encryptedBankAccountInfo = new EncryptedBankAccountInfo());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				encryptedBankAccountInfo = value;
			}
		}

		#endregion
	}
}

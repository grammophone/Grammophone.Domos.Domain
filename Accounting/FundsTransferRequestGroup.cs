using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		#region Constants

		/// <summary>
		/// The maximum length for the <see cref="AccountHolderName"/> property.
		/// </summary>
		public const int AccountHolderNameLength = 64;

		/// <summary>
		/// The maximum length for the <see cref="AccountHolderToken"/> property.
		/// </summary>
		public const int AccountHolderTokenLength = 36;

		#endregion

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

		/// <summary>
		/// The name of the bank account holder.
		/// </summary>
		[Required]
		[MaxLength(AccountHolderNameLength)]
		public virtual string AccountHolderName { get; set; }

		/// <summary>
		/// Optinoal token identifying the bank account holder.
		/// </summary>
		[MaxLength(AccountHolderTokenLength)]
		public virtual string AccountHolderToken { get; set; }

		#endregion
	}
}

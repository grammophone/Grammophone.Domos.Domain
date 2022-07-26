using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Embeddable record for the encrypted specification of a bank account.
	/// </summary>
	[Serializable]
	public class EncryptedBankAccountInfo : IEquatable<EncryptedBankAccountInfo>
	{
		#region Public properties

		/// <summary>
		/// The encrypted account number.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual byte[] EncryptedAccountNumber { get; set; }

		/// <summary>
		/// The bank number, used in Canada.
		/// </summary>
		[MaxLength(6)]
		public virtual string BankNumber { get; set; }

		/// <summary>
		/// The encrypted transit number, specified in the cheque.
		/// </summary>
		[MaxLength(32)]
		public virtual byte[] EncryptedTransitNumber { get; set; }

		/// <summary>
		/// Account code, used in United states.
		/// </summary>
		[MaxLength(6)]
		public virtual string AccountCode { get; set; }

		/// <summary>
		/// Optional type, when the system supports many bank account
		/// formats at the same time.
		/// </summary>
		[MaxLength(12)]
		public virtual string Type { get; set; }

		#endregion

		#region IEquatable<EncryptedBankAccountInfo> implemenation

		/// <inheritdoc/>
		public bool Equals(EncryptedBankAccountInfo other)
		{
			if (other == null) return false;

			return this.BankNumber == other.BankNumber 
				&& this.AccountCode == other.AccountCode
				&& AreByteArraysEqual(this.EncryptedAccountNumber, other.EncryptedAccountNumber)
				&& AreByteArraysEqual(this.EncryptedTransitNumber, other.EncryptedTransitNumber)
				&& this.Type == other.Type;
		}

		#endregion

		#region Object.Equals and GetHashCode implementation

		/// <summary>
		/// Delegates to <see cref="Equals(EncryptedBankAccountInfo)"/> method.
		/// </summary>
		public override bool Equals(object obj) => this.Equals(obj as EncryptedBankAccountInfo);

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = 947222550;

				var byteArrayEqualityComparer = EqualityComparer<byte[]>.Default;

				hashCode = hashCode * -1521134295 + GetByteArrayHashCode(this.EncryptedAccountNumber);
				hashCode = hashCode * -1521134295 + GetByteArrayHashCode(this.EncryptedTransitNumber);
				hashCode = hashCode * -1521134295 + this.AccountCode?.GetHashCode() ?? 17;
				hashCode = hashCode * -1521134295 + this.BankNumber?.GetHashCode() ?? 7;
				hashCode = hashCode * -1521134295 + this.Type?.GetHashCode() ?? 13;

				return hashCode;
			}
		}

		/// <summary>
		/// Deleates to <see cref="Equals(EncryptedBankAccountInfo)"/>.
		/// </summary>
		public static bool operator ==(EncryptedBankAccountInfo left, EncryptedBankAccountInfo right)
		{
			if (Object.ReferenceEquals(left, null)) return Object.ReferenceEquals(right, null);

			return left.Equals(right);
		}

		/// <summary>
		/// Deleates to <see cref="Equals(EncryptedBankAccountInfo)"/> inverted.
		/// </summary>
		public static bool operator !=(EncryptedBankAccountInfo left, EncryptedBankAccountInfo right) => !(left == right);

		#endregion

		#region Private methods

		private static bool AreByteArraysEqual(byte[] array1, byte[] array2)
		{
			if (array1 == array2) return true;

			if (array1 == null || array2 == null) return false;
			
			if (array1.Length != array2.Length) return false;

			return array2.SequenceEqual(array2);
		}

		private static int GetByteArrayHashCode(byte[] array)
		{
			if (array == null) return 0;

			unchecked
			{
				int hash = 17;

				for (int byteCount = array.Length > 4 ? 4 : array.Length, i = 0; i < byteCount; i++)
				{
					hash = hash * 31 + array[i];
				}

				return hash;
			}
		}

		#endregion
	}
}

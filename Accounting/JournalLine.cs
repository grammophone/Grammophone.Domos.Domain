using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Base for accounting record lines in a journal, having group ownership.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="A">The type of account, derived from <see cref="Account{U}"/>.</typeparam>
	[Serializable]
	public abstract class JournalLine<U, A> : UserGroupTrackingEntityWithID<U, long>
		where U : User
		where A : Account<U>
	{
		#region Private fields

		#endregion

		#region Primitive properties

		/// <summary>
		/// The amount added to the <see cref="Account"/>, if positive, or subtracted, if negative.
		/// </summary>
		public virtual decimal Amount { get; set; }

		/// <summary>
		/// Optional description of the journal line.
		/// </summary>
		public virtual string Description { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the account where this journal line applies.
		/// </summary>
		public virtual long AccountID { get; set; }

		/// <summary>
		/// The account where this journal line applies.
		/// </summary>
		public virtual A Account { get; set; }

		#endregion
	}
}

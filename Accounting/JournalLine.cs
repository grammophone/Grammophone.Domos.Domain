using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// Base for accounting record lines in a journal.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class JournalLine<U> : UserGroupTrackingEntityWithID<U, long>
		where U : User
	{
		#region Primitive properties

		/// <summary>
		/// The amount added to the <see cref="Account"/>, if positive, or subtracted, if negative.
		/// </summary>
		public virtual decimal Amount { get; set; }

		/// <summary>
		/// Optional description of the journal line.
		/// </summary>
		public virtual string Description { get; set; }

		/// <summary>
		/// Application-defined type of the line.
		/// </summary>
		public virtual int Type { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the account where this journal line applies.
		/// </summary>
		public virtual long AccountID { get; set; }

		/// <summary>
		/// The account where this journal line applies.
		/// </summary>
		public virtual Account<U> Account { get; set; }

		/// <summary>
		/// The ID of the journal where this line belongs.
		/// </summary>
		public virtual long JournalID { get; set; }

		/// <summary>
		/// The journal where this line belongs.
		/// </summary>
		public virtual Journal<U> Journal { get; set; }

		#endregion
	}
}

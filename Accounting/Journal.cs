using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// Base for account entities.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public class Journal<U> : UserGroupTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private ICollection<JournalLine<U>> lines;

		#endregion

		#region Primitive properties

		/// <summary>
		/// Primary key.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// Applicatoin-defined categorization of the journal.
		/// </summary>
		public virtual int Type { get; set; }

		/// <summary>
		/// Optional description of the journal.
		/// </summary>
		public virtual string Description { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// Optional ID of the workflow state transition associated with this journal.
		/// </summary>
		public virtual long? StateTransitionID { get; set; }

		/// <summary>
		/// Optional workflow state transition associated with this journal.
		/// </summary>
		public virtual Workflow.StateTransition<U> StateTransition { get; set; }

		/// <summary>
		/// The lines contained in this journal.
		/// </summary>
		public virtual ICollection<JournalLine<U>> Lines
		{
			get
			{
				return lines ?? (lines = new HashSet<JournalLine<U>>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				lines = value;
			}
		}

		#endregion

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Base for accounting journals, having group ownership.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="ST">The type of state transition, derived from <see cref="Workflow.StateTransition{U}"/>.</typeparam>
	/// <typeparam name="A">The type of accounts, derived from <see cref="Account{U}"/>.</typeparam>
	/// <typeparam name="P">The type of the postings, derived from <see cref="Posting{U, A}"/>.</typeparam>
	/// <typeparam name="R">The type of remittances, derived from <see cref="Remittance{U, A}"/>.</typeparam>
	[Serializable]
	public abstract class Journal<U, ST, A, P, R> : UserGroupTrackingEntityWithID<U, long>
		where U : User
		where ST : Workflow.StateTransition<U>
		where A : Account<U>
		where P : Posting<U, A>
		where R : Remittance<U, A>
	{
		#region Private fields

		private ICollection<P> postings;

		private ICollection<R> remittances;

		#endregion

		#region Primitive properties

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
		public virtual ST StateTransition { get; set; }

		/// <summary>
		/// The postings in this journal.
		/// </summary>
		public virtual ICollection<P> Postings
		{
			get
			{
				return postings ?? (postings = new HashSet<P>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				postings = value;
			}
		}

		/// <summary>
		/// The remittances in this journal.
		/// </summary>
		public virtual ICollection<R> Remittances
		{
			get
			{
				return remittances ?? (remittances = new HashSet<R>());
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

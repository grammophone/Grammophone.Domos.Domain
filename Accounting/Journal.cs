using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
	/// <typeparam name="BST">
	/// The base type of system's state transitions, derived from <see cref="Workflow.StateTransition{U}"/>.
	/// </typeparam>
	/// <typeparam name="P">The type of the postings, derived from <see cref="Posting{U}"/>.</typeparam>
	/// <typeparam name="R">The type of remittances, derived from <see cref="Remittance{U}"/>.</typeparam>
	[Serializable]
	public abstract class Journal<U, BST, P, R> : TrackingEntityWithID<U, long>
		where U : User
		where BST : Workflow.StateTransition<U>
		where P : Posting<U>
		where R : Remittance<U>
	{
		#region Private fields

		private ICollection<P> postings;

		private ICollection<R> remittances;

		#endregion

		#region Primitive properties

		/// <summary>
		/// Optional description of the journal.
		/// </summary>
		[Display(
			ResourceType = typeof(JournalResources),
			Name = nameof(JournalResources.Description_Name))]
		public virtual string Description { get; set; }

		/// <summary>
		/// If true, the journal's lines have been executed and moved amounts to the respective accounts.
		/// </summary>
		[Display(
			ResourceType = typeof(JournalResources),
			Name = nameof(JournalResources.HasBeenExecuted_Name))]
		public virtual bool HasBeenExecuted { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// Optional ID of the workflow state transition associated with this journal.
		/// </summary>
		public virtual long? StateTransitionID { get; set; }

		/// <summary>
		/// Optional workflow state transition associated with this journal.
		/// </summary>
		public virtual BST StateTransition { get; set; }

		/// <summary>
		/// Optional ID of associated successful funds transfer event.
		/// </summary>
		/// <remarks>
		/// The event must have <see cref="FundsTransferEvent.Type"/> 
		/// set to <see cref="FundsTransferEventType.Succeeded"/>.
		/// </remarks>
		public virtual long? FundsTransferEventID { get; set; }

		/// <summary>
		/// Optional associated successful funds transfer event.
		/// </summary>
		/// <remarks>
		/// The event must have <see cref="FundsTransferEvent.Type"/> 
		/// set to <see cref="FundsTransferEventType.Succeeded"/>.
		/// </remarks>
		public virtual FundsTransferEvent FundsTransferEvent { get; set; }

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

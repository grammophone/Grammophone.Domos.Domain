using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammophone.Domos.Domain.Accounting;

namespace Grammophone.Domos.Domain.Workflow
{
	/// <summary>
	/// A recording of a state transition via a <see cref="StatePath"/>.
	/// Remember to eager fetch the inherited <see cref="IUserGroupTrackingEntity{U}.OwningUsers"/> property
	/// when retrieving a list of entities of this type to avoid a 'n+1' performance penalty.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class StateTransition<U> : TrackingEntityWithID<U, long>
		where U : User
	{
		#region Primitive properties

		/// <summary>
		/// The value of the stateful object's <see cref="IStateful{U, ST}.ChangeStamp"/> before the execution
		/// of the <see cref="Path"/>.
		/// </summary>
		public virtual int ChangeStampBefore { get; set; }

		/// <summary>
		/// The value of the stateful object's <see cref="IStateful{U, ST}.ChangeStamp"/> after the execution
		/// of the <see cref="Path"/>.
		/// </summary>
		public virtual int ChangeStampAfter { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the <see cref="StatePath"/> which was executed for the transition.
		/// </summary>
		public virtual long PathID { get; set; }

		/// <summary>
		/// The <see cref="StatePath"/> which was executed for the transition.
		/// </summary>
		public virtual StatePath Path { get; set; }

		/// <summary>
		/// The ID of an optional funds transfer event associated with the state transition.
		/// </summary>
		public virtual long? FundsTransferEventID { get; set; }

		/// <summary>
		/// Optional funds transfer event associated with the state transition.
		/// </summary>
		public virtual FundsTransferEvent FundsTransferEvent { get; set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Bind this transition to an <see cref="IStateful{U, ST}"/> instance.
		/// </summary>
		/// <exception cref="DomainException">
		/// Thrown when the <paramref name="stateful"/> instance is not compatible
		/// to this state transition.
		/// </exception>
		public abstract void BindToStateful(IStateful<U, StateTransition<U>> stateful);

		#endregion
	}
}

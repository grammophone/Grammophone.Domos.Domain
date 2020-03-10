using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Workflow
{
	/// <summary>
	/// Abstract contract for entities having a state in a workflow.
	/// </summary>
	public interface IStateful : IEntityWithID<long>
	{
		/// <summary>
		/// The current <see cref="State"/> of the object.
		/// </summary>
		State State { get; set; }

		/// <summary>
		/// The change stamp of the object. 
		/// Typically it is used to mark 'unread' or 'dirty' objects.
		/// It is automatically updated upon successful <see cref="StatePath"/> execution
		/// by the <see cref="StatePath.ChangeStampANDMask"/> and <see cref="StatePath.ChangeStampORMask"/>
		/// properties.
		/// </summary>
		int ChangeStamp { get; set; }

		/// <summary>
		/// The last date, in UTC, when the <see cref="State"/> was changed, if any, else null.
		/// </summary>
		DateTime? LastStateChangeDate { get; set; }

		/// <summary>
		/// Last date, in UTC, when the transition of the <see cref="State"/> has crossed barriers of a state group,
		/// or null if it didn't happen.
		/// </summary>
		DateTime? LastStateGroupChangeDate { get; set; }

		/// <summary>
		/// Get the domain entity supporting the stateful object.
		/// </summary>
		/// <remarks>
		/// In the common case, where the <see cref="IStateful"/> implementation is
		/// a domain entity itself, just return 'this'.
		/// Else, when a domain entity has multiple states and we need an adapter pattern to return
		/// multiple <see cref="IStateful"/> implementations, return the underlying entity.
		/// </remarks>
		object GetBackingEntity();
	}

	/// <summary>
	/// Contract for entities having a state in a workflow.
	/// </summary>
	/// <typeparam name="U">The type of the users, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="ST">The type of state transitions, derived from <see cref="StateTransition{U}"/>.</typeparam>
	public interface IStateful<U, ST> : IStateful, ITrackingEntity<U>
		where U : User
		where ST : StateTransition<U>
	{
		/// <summary>
		/// The history of state transitions of this object.
		/// </summary>
		ICollection<ST> StateTransitions { get; set; }
	}
}

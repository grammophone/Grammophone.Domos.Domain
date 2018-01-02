using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Workflow
{
	/// <summary>
	/// Contract for entities having a state in a workflow.
	/// </summary>
	/// <typeparam name="U">The type of the users, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="ST">The type of state transitions, derived from <see cref="StateTransition{U}"/>.</typeparam>
	public interface IStateful<U, ST> : ITrackingEntity<U>, IEntityWithID<long>
		where U : User
		where ST : StateTransition<U>
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
		/// The history of state transitions of this object.
		/// </summary>
		ICollection<ST> StateTransitions { get; }
	}
}

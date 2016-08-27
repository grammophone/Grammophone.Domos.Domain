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
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	public interface IStateful<U> : ITrackingEntity<U>
		where U : User
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
		/// The history of state transitions of this object.
		/// </summary>
		ICollection<StateTransition<U>> Transitions { get; }
	}
}

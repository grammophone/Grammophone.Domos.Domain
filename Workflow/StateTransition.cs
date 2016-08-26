using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Workflow
{
	/// <summary>
	/// A recording of a state transition via a <see cref="StatePath"/>.
	/// Remember to eager fetch the inherited <see cref="IUserGroupTrackingEntity{U}.OwningUsers"/> property
	/// when retrieving a list of entities of this type to avoid a 'n+1' performance penalty.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public class StateTransition<U> : UserGroupTrackingEntityWithID<U, long>
		where U : User
	{
		#region Private fields

		private ICollection<Attachment<U>> attachments;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The value of the stateful object's <see cref="IStateful{U}.ChangeStamp"/> before the execution
		/// of the <see cref="Path"/>.
		/// </summary>
		public virtual int ChangeStampBefore { get; set; }

		/// <summary>
		/// The value of the stateful object's <see cref="IStateful{U}.ChangeStamp"/> after the execution
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
		/// Optional attachments accompanying this state transition.
		/// </summary>
		public virtual ICollection<Attachment<U>> Attachments
		{
			get
			{
				return attachments ?? (attachments = new HashSet<Attachment<U>>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				attachments = value;
			}
		}

		#endregion
	}
}

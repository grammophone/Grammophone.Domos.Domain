using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Workflow
{
	/// <summary>
	/// A grouping of workflow states.
	/// </summary>
	[Serializable]
	public class StateGroup
	{
		#region Private fields

		private ICollection<State> states;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The primary key.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// The code name of the state group.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string Code { get; set; }

		/// <summary>
		/// The name of the state path.
		/// </summary>
		public virtual string Name { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The states belonging to this group.
		/// </summary>
		public virtual ICollection<State> States
		{
			get
			{
				return states ?? (states = new HashSet<State>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				states = value;
			}
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Workflow
{
	/// <summary>
	/// A directged graph of states representing a workflow.
	/// </summary>
	[Serializable]
	public class WorkflowGraph : EntityWithID<long>
	{
		#region Private fields

		private ICollection<StateGroup> stateGroups;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The code name of the workflow graph.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string Code { get; set; }

		/// <summary>
		/// The name of the workflow graph.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// The description of the workflow graph.
		/// </summary>
		public virtual string Description { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The groups of states in this workflow.
		/// </summary>
		public virtual ICollection<StateGroup> StateGroups
		{
			get
			{
				return stateGroups ?? (stateGroups = new HashSet<StateGroup>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				stateGroups = value;
			}
		}

		#endregion
	}
}

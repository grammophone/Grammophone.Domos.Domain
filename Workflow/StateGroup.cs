using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Workflow
{
	/// <summary>
	/// A grouping of workflow states.
	/// </summary>
	[Serializable]
	public class StateGroup : EntityWithID<long>
	{
		#region Private fields

		private ICollection<State> states;

		#endregion

		#region Primitive properties

	/// <summary>
		/// The code name of the state group.
		/// </summary>
		[Required]
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(StateGroupResources),
			Name = nameof(StateGroupResources.CodeName_Name))]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// The name of the state path.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[Display(
			ResourceType = typeof(StateGroupResources),
			Name = nameof(StateGroupResources.Name_Name))]
		public virtual string Name { get; set; }

		/// <summary>
		/// Optional description of the state group.
		/// </summary>
		[Display(
			ResourceType = typeof(StateGroupResources),
			Name = nameof(StateGroupResources.Description_Name))]
		public virtual string Description { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the workflow graph where this group of states belongs.
		/// </summary>
		public virtual long WorkflowGraphID { get; set; }

		/// <summary>
		/// The workflow graph where this group of states belongs.
		/// </summary>
		public virtual WorkflowGraph WorkflowGraph { get; set; }

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

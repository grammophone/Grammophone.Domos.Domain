using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Workflow
{
	/// <summary>
	/// A vertex in a workflow graph.
	/// </summary>
	[Serializable]
	public class State : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// A code name for the state.
		/// </summary>
		[Required]
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(StateResources),
			Name = nameof(WorkflowGraphResources.CodeName_Name))]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// The name of the state.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[Display(
			ResourceType = typeof(StateResources),
			Name = nameof(WorkflowGraphResources.Name_Name))]
		public virtual string Name { get; set; }

		/// <summary>
		/// Optional description of the state.
		/// </summary>
		[Display(
			ResourceType = typeof(StateResources),
			Name = nameof(WorkflowGraphResources.Description_Name))]
		public virtual string Description { get; set; }

		/// <summary>
		/// True if this is intended to be a start state.
		/// </summary>
		public virtual bool IsStart { get; set; }

		/// <summary>
		/// True if this is intended to be an end state.
		/// </summary>
		public virtual bool IsEnd { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the group where this state belongs.
		/// </summary>
		public virtual long GroupID { get; set; }

		/// <summary>
		/// The group where this state belongs.
		/// </summary>
		public virtual StateGroup Group { get; set; }

		#endregion
	}
}

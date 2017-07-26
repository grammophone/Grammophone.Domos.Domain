using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Workflow
{
	/// <summary>
	/// A possible path from one workflow state to another,
	/// ie an edge in a workflow graph.
	/// </summary>
	[Serializable]
	public class StatePath : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// The path's code name.
		/// </summary>
		[Required]
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(StatePathResources), 
			Name = nameof(StatePathResources.CodeName_Name))]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// The name of the path.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[Display(
			ResourceType = typeof(StatePathResources),
			Name = nameof(StatePathResources.Name_Name))]
		public virtual string Name { get; set; }

		/// <summary>
		/// Optional description of the path.
		/// </summary>
		[Display(
			ResourceType = typeof(StatePathResources),
			Name = nameof(StatePathResources.Description_Name))]
		public virtual string Description { get; set; }

		/// <summary>
		/// Optional order specification for paths originating from 
		/// common start state.
		/// </summary>
		public virtual int Order { get; set; }

		/// <summary>
		/// Optional arbitrary categorization. 
		/// If used, it is interpreted by applications.
		/// </summary>
		public virtual long Categorization { get; set; }

		/// <summary>
		/// Optional arbitrary visibility. 
		/// If used, it is interpreted by applications.
		/// </summary>
		public virtual int Visibility { get; set; }

		/// <summary>
		/// Applied with AND operator to an <see cref="IStateful{U, ST}.ChangeStamp"/> upon successful execution.
		/// </summary>
		public virtual int ChangeStampANDMask { get; set; }

		/// <summary>
		/// Applied with OR operator to an <see cref="IStateful{U, ST}.ChangeStamp"/> upon successful execution.
		/// </summary>
		public virtual int ChangeStampORMask { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// ID of originating <see cref="State"/>.
		/// </summary>
		public virtual long PreviousStateID { get; set; }

		/// <summary>
		/// Originating <see cref="State"/>.
		/// </summary>
		public virtual State PreviousState { get; set; }

		/// <summary>
		/// ID of destination <see cref="State"/>.
		/// </summary>
		public virtual long NextStateID { get; set; }

		/// <summary>
		/// Destination <see cref="State"/>.
		/// </summary>
		public virtual State NextState { get; set; }

		/// <summary>
		/// The ID of the workflow graph where this path vertex belongs.
		/// </summary>
		public virtual long WorkflowGraphID { get; set; }

		/// <summary>
		/// The workflow graph where this path vertex belongs.
		/// </summary>
		public virtual WorkflowGraph WorkflowGraph { get; set; }

		#endregion
	}
}

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
			Name = nameof(StateResources.CodeName_Name),
			Description = nameof(StateResources.CodeName_Description))]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// The display name of the state.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[Display(
			ResourceType = typeof(StateResources),
			Name = nameof(StateResources.Name_Name),
			Description = nameof(StateResources.Name_Description))]
		public virtual string Name { get; set; }

		/// <summary>
		/// Optional description of the state.
		/// </summary>
		[Display(
			ResourceType = typeof(StateResources),
			Name = nameof(StateResources.Description_Name),
			Description =nameof(StateResources.Description_Description))]
		public virtual string Description { get; set; }

		/// <summary>
		/// True if this is intended to be a start state.
		/// </summary>
		[Display(
			ResourceType = typeof(StateResources),
			Name = nameof(StateResources.IsStart_Name),
			Description = nameof(StateResources.IsStart_Description))]
		public virtual bool IsStart { get; set; }

		/// <summary>
		/// True if this is intended to be an end state.
		/// </summary>
		[Display(
			ResourceType = typeof(StateResources),
			Name = nameof(StateResources.IsEnd_Name),
			Description = nameof(StateResources.IsEnd_Description))]
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

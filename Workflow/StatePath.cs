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
		#region Private fields

		private ICollection<Role> allowingRoles;

		private ICollection<DispositionType> allowingDispositionTypes;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The path's code name.
		/// </summary>
		[Required]
		[MaxLength(128)]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// The name of the path.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// The description of the path.
		/// </summary>
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
		/// Applied with AND operator to an <see cref="IStateful{U}.ChangeStamp"/> upon successful execution.
		/// </summary>
		public virtual int ChangeStampANDMask { get; set; }

		/// <summary>
		/// Applied with OR operator to an <see cref="IStateful{U}.ChangeStamp"/> upon successful execution.
		/// </summary>
		public virtual int ChangeStampORMask { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// ID of originating <see cref="State"/>.
		/// </summary>
		public virtual long FromStateID { get; set; }

		/// <summary>
		/// Originating <see cref="State"/>.
		/// </summary>
		public virtual State FromState { get; set; }

		/// <summary>
		/// ID of destination <see cref="State"/>.
		/// </summary>
		public virtual long ToStateID { get; set; }

		/// <summary>
		/// Destination <see cref="State"/>.
		/// </summary>
		public virtual State ToState { get; set; }

		/// <summary>
		/// The system-wide roles which allow the execution of this path.
		/// </summary>
		public virtual ICollection<Role> AllowingRoles
		{
			get
			{
				return allowingRoles ?? (allowingRoles = new HashSet<Role>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				allowingRoles = value;
			}
		}

		/// <summary>
		/// The segregation-wide roles which allow the execution of this path.
		/// </summary>
		public virtual ICollection<DispositionType> AllowingDispositionTypes
		{
			get
			{
				return allowingDispositionTypes ?? (allowingDispositionTypes = new HashSet<DispositionType>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				allowingDispositionTypes = value;
			}
		}

		#endregion
	}
}

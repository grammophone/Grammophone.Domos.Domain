using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// Records the attempt of an execution of a workflow state path
	/// associated with a <see cref="FundsTransferEvent"/>.
	/// </summary>
	[Serializable]
	public class WorkflowExecution : TrackingEntityWithID<User, long>
	{
		#region Primitive properties

		/// <summary>
		/// If true, the workflow execution associated with the funds transfer event succeeded.
		/// </summary>
		public virtual bool Succeeded { get; set; }

		/// <summary>
		/// If <see cref="Succeeded"/> is false, this property holds the serialized exception.
		/// </summary>
		public virtual byte[] ExceptionData { get; set; }

		/// <summary>
		/// If <see cref="Succeeded"/> is false and there is a user-oriented message in the thrown exception,
		/// it is recorded in this property.
		/// </summary>
		[MaxLength(512)]
		public virtual string Message { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the funds transfer event which triggered the workflow execution.
		/// </summary>
		public virtual long EventID { get; set; }

		/// <summary>
		/// The funds transfer event which triggered the workflow execution.
		/// </summary>
		public virtual FundsTransferEvent Event { get; set; }

		/// <summary>
		/// The ID of the state path which was attempted to be executed.
		/// </summary>
		public virtual long StatePathID { get; set; }

		/// <summary>
		/// The state path which was attempted to be executed.
		/// </summary>
		public virtual Workflow.StatePath StatePath { get; set; }

		#endregion
	}
}

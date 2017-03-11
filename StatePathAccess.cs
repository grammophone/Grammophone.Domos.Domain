using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Depicts an allowed access to a <see cref="Workflow.StatePath"/>.
	/// </summary>
	[Serializable]
	public class StatePathAccess : IEntityWithID<int>
	{
		#region Primitive properties

		/// <summary>
		/// The primary key. User only when stored in database.
		/// </summary>
		public virtual int ID { get; set; }

		/// <summary>
		/// The <see cref="Workflow.StatePath.CodeName"/> of
		/// the <see cref="Workflow.StatePath"/>.
		/// </summary>
		public virtual string StatePathCodeName { get; set; }

		#endregion
	}
}

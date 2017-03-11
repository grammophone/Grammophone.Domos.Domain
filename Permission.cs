using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// An abstraction of allowed behavior.
	/// </summary>
	[Serializable]
	public class Permission : IEntityWithID<int>
	{
		#region Private fields

		private ICollection<EntityAccess> entityAccesses;

		private ICollection<ManagerAccess> managerAccesses;

		private ICollection<StatePathAccess> statePathAccesses;

		#endregion

		#region Primitive properties

		/// <summary>
		/// Primary key. Used only if the instance is stored in the database.
		/// </summary>
		public virtual int ID { get; set; }

		/// <summary>
		/// A descriptive name of the permission.
		/// </summary>
		[Required]
		[MaxLength(256)]
		public virtual string Name { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// These are the entity accesses associated to the permission.
		/// </summary>
		public virtual ICollection<EntityAccess> EntityAccesses
		{
			get
			{
				return entityAccesses ?? (entityAccesses = new HashSet<EntityAccess>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				entityAccesses = value;
			}
		}

		/// <summary>
		/// These are the entity accesses associated to the permission.
		/// </summary>
		public virtual ICollection<ManagerAccess> ManagerAccesses
		{
			get
			{
				return managerAccesses ?? (managerAccesses = new HashSet<ManagerAccess>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				managerAccesses = value;
			}
		}

		/// <summary>
		/// These are the state path accesses associated to the permission.
		/// </summary>
		public virtual ICollection<StatePathAccess> StatePathAccesses
		{
			get
			{
				return statePathAccesses ?? (statePathAccesses = new HashSet<StatePathAccess>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				statePathAccesses = value;
			}
		}

		#endregion
	}
}

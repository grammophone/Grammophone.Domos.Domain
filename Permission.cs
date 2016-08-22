using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// An abstraction of allowed behavior.
	/// </summary>
	[Serializable]
	public class Permission
	{
		#region Private fields

		private ICollection<EntityAccess> entityAccesses;

		private ICollection<ManagerAccess> managerAccesses;

		#endregion

		#region Primitive fields

		/// <summary>
		/// A unique code name for the permission.
		/// </summary>
		[Required]
		[Key]
		public virtual string ID { get; set; }

		/// <summary>
		/// A descriptive name of the permission.
		/// </summary>
		[Required]
		public virtual string Name { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// Only when these are persisted in database, 
		/// these are the entity accesses associated to the permission.
		/// </summary>
		/// <remarks>
		/// This collection is not used when the entity accesses are defined elsewhere.
		/// </remarks>
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
		/// Only when these are persisted in database, 
		/// these are the entity accesses associated to the permission.
		/// </summary>
		/// <remarks>
		/// This collection is not used when the entity accesses are defined elsewhere.
		/// </remarks>
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

		#endregion
	}
}

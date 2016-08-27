using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Defines access to en entity type by a user or a user's disposition.
	/// </summary>
	[Serializable]
	public class EntityAccess
	{
		#region Primitive properties

		/// <summary>
		/// Primary key. Used only if the instance is stored in the database.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// The full name of the entity class for which access is defined.
		/// </summary>
		public virtual string EntityName { get; set; }

		/// <summary>
		/// If true, the user can create entities of the requested type.
		/// </summary>
		public virtual bool CanCreate { get; set; }

		/// <summary>
		/// If true, the user can read entities of the requested type.
		/// </summary>
		public virtual bool CanRead { get; set; }

		/// <summary>
		/// If true, the user can read entities created by her of the requested 
		/// type. This applies to entities implementing <see cref="IUserTrackingEntity{U}"/>.
		/// </summary>
		public virtual bool CanReadOwn { get; set; }

		/// <summary>
		/// If true, the user can read entities of the requested type.
		/// </summary>
		public virtual bool CanWrite { get; set; }

		/// <summary>
		/// If true, the user can read entities created by her of the requested 
		/// type. This applies to entities implementing <see cref="IUserTrackingEntity{U}"/>.
		/// </summary>
		public virtual bool CanWriteOwn { get; set; }

		/// <summary>
		/// If true, the user can delete entities of the requested type.
		/// </summary>
		public virtual bool CanDelete { get; set; }

		/// <summary>
		/// If true, the user can delete entities created by her of the requested 
		/// type. This applies to entities implementing <see cref="IUserTrackingEntity{U}"/>.
		/// </summary>
		public virtual bool CanDeleteOwn { get; set; }

		#endregion
	}
}

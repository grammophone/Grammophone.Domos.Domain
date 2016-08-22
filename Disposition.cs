using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// A participation of a user to a segregation of the system.
	/// </summary>
	[Serializable]
	public class Disposition
	{
		#region Primitive properties

		/// <summary>
		/// The primary key.
		/// </summary>
		public virtual long ID { get; set; }

		/// <summary>
		/// The ID of the segregation.
		/// </summary>
		public virtual long SegregationID { get; set; }

		/// <summary>
		/// If true, this disposition is active.
		/// </summary>
		public virtual bool IsActive { get; set; }

		#endregion

		#region Relationships

		/// <summary>
		/// The ID of the owner of the disposition.
		/// </summary>
		public virtual long UserID { get; set; }

		/// <summary>
		/// The ID of the type of the disposition for this <see cref="SegregationID"/>.
		/// </summary>
		public virtual long TypeID { get; set; }

		/// <summary>
		/// The type of the disposition for this <see cref="SegregationID"/>.
		/// </summary>
		public virtual DispositionType Type { get; set; }

		#endregion
	}

	/// <summary>
	/// A participation of a user to a segregation of the system,
	/// with strong-type reference to the user.
	/// </summary>
	/// <typeparam name="U">The type of the user.</typeparam>
	[Serializable]
	public class Disposition<U> : Disposition
		where U : User
	{
		/// <summary>
		/// The the owner of the disposition.
		/// </summary>
		public virtual U User { get; set; }
	}
}

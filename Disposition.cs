using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A participation of a user to a segregation of the system.
	/// It is a kind of role within a segregation.
	/// </summary>
	/// <remarks>
	/// In derived classes, if you want to create a foreign key from <see cref="SegregationID"/>
	/// to a strong-type navigation property, typically of type <see cref="Segregation{U}"/>,
	/// either add a [ForeignKey("SegregationID")] attribute to it or set it manually
	/// according to your data access implementation. 
	/// For Entity Framework 6.1.x, only the first approach seems to work.
	/// </remarks>
	/// <example>
	/// <code>
	/// [ForeignKey("SegregationID")]
	/// public virtual Companies.Company Company { get; set; }
	/// </code> 
	/// </example>
	[Serializable]
	public abstract class Disposition
		: UserTrackingEntityWithID<User, long>, IDisposition
	{
		#region Primitive properties

		/// <summary>
		/// The state of this disposition.
		/// </summary>
		[Display(
			ResourceType = typeof(DispositionResources),
			Name = nameof(DispositionResources.Status_Name))]
		public virtual DispositionStatus Status { get; set; }

		/// <summary>
		/// The ID of the segregation. Map this to the foreign key to the segregating entity.
		/// </summary>
		public abstract long SegregationID { get; }

		#endregion

		#region Relations

		/// <summary>
		/// The owner of the disposition.
		/// </summary>
		/// <remarks>
		/// This override removes the inherited IgnoreMember attribute,
		/// in order to make the property accessible.
		/// </remarks>
		public override User OwningUser
		{
			get
			{
				return base.OwningUser;
			}
			set
			{
				base.OwningUser = value;
			}
		}

		/// <summary>
		/// The ID of the type of this disposition.
		/// </summary>
		public virtual long TypeID { get; set; }

		/// <summary>
		/// The type of this disposition.
		/// </summary>
		public virtual DispositionType Type { get; set; }

		#endregion
	}
}

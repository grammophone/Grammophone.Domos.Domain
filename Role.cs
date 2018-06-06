using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Role assigned to users.
	/// </summary>
	[Serializable]
	public class Role : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// The display name of the role.
		/// </summary>
		[Required]
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(RoleResources),
			Name = nameof(RoleResources.Name_Name),
			Description = nameof(RoleResources.Name_Description))]
		public virtual string Name { get; set; }

		/// <summary>
		/// The code name of the role, to be referred by the system.
		/// </summary>
		[Required]
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(RoleResources),
			Name = nameof(RoleResources.CodeName_Name),
			Description = nameof(RoleResources.CodeName_Description))]
		public virtual string CodeName { get; set; }

		#endregion
	}
}

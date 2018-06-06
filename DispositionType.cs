using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A segregation-wide role. Uses are linked to this type of roles via descendants of <see cref="Disposition"/>s
	/// whose classes are specified in the <see cref="ClassName"/> proeprty.
	/// </summary>
	[Serializable]
	public class DispositionType : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// The display name of the disposition type.
		/// </summary>
		[Required]
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(DispositionTypeResources),
			Name = nameof(DispositionTypeResources.Name_Name),
			Description = nameof(DispositionTypeResources.Name_Description))]
		public virtual string Name { get; set; }

		/// <summary>
		/// The code name of the disposition type.
		/// </summary>
		[Required]
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(DispositionTypeResources),
			Name = nameof(DispositionTypeResources.CodeName_Name),
			Description = nameof(DispositionTypeResources.CodeName_Description))]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// The full .NET class name of dispositions of this type.
		/// </summary>
		[Required]
		[MaxLength(512)]
		[Display(
			ResourceType = typeof(DispositionTypeResources),
			Name = nameof(DispositionTypeResources.ClassName_Name),
			Description = nameof(DispositionTypeResources.ClassName_Description))]
		public virtual string ClassName { get; set; }

		#endregion
	}
}

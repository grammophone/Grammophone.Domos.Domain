using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A segregation-wide role.
	/// </summary>
	[Serializable]
	public class DispositionType : EntityWithID<long>
	{
		#region Primitive properties

		/// <summary>
		/// The name of the segregation-wide role.
		/// </summary>
		[Required]
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(DispositionTypeResources),
			Name = nameof(DispositionTypeResources.Name_Name))]
		public virtual string Name { get; set; }

		/// <summary>
		/// The code name of a the segregation-wide role.
		/// </summary>
		[Required]
		[MaxLength(128)]
		[Display(
			ResourceType = typeof(DispositionTypeResources),
			Name = nameof(DispositionTypeResources.CodeName_Name))]
		public virtual string CodeName { get; set; }

		/// <summary>
		/// The full .NET class name of dispositions of this type.
		/// </summary>
		[Required]
		[MaxLength(512)]
		[Display(
			ResourceType = typeof(DispositionTypeResources),
			Name = nameof(DispositionTypeResources.ClassName_Name))]
		public virtual string ClassName { get; set; }

		#endregion
	}
}

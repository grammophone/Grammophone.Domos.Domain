using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Thrown when there is a violation of the security defined for the entities of the domain model.
	/// </summary>
	[Serializable]
	public class AccessDeniedDomainException : DomainException, IEntityAccessDeniedException
	{
		/// <summary>
		/// The type name of the entity under violation.
		/// </summary>
		public string EntityName { get; private set; }

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="entity">The entity under violation.</param>
		public AccessDeniedDomainException(string message, object entity) 
			: base(message)
		{
			this.EntityName = GetEntityTypeName(entity);
		}

		/// <summary>
		/// Used for serialization.
		/// </summary>
		protected AccessDeniedDomainException(
		System.Runtime.Serialization.SerializationInfo info,
		System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Takes care of possible proxy classes containing '_' in their name.
		/// </summary>
		private static string GetEntityTypeName(object entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));

			Type type = entity.GetType();

			if (type.Name.Contains('_') && type.BaseType != null)
				return type.BaseType.FullName;
			else
				return type.FullName;
		}
	}
}

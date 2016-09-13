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
	public class AccessDeniedDomainException : DomainException
	{
		/// <summary>
		/// The entity under violation.
		/// </summary>
		public object Entity { get; private set; }

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="entity">The entity under violation.</param>
		public AccessDeniedDomainException(string message, object entity) 
			: base(message)
		{
			this.Entity = entity;
		}

		/// <summary>
		/// Used for serialization.
		/// </summary>
		protected AccessDeniedDomainException(
		System.Runtime.Serialization.SerializationInfo info,
		System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}

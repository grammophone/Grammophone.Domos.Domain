using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Extension methods for entities implementing the Domos interfaces.
	/// </summary>
	public static class EntityExtensionMethods
	{
		/// <summary>
		/// Inherit the owners of an entity.
		/// </summary>
		/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
		/// <param name="targetEntity">The receiving entity.</param>
		/// <param name="sourceEntity">The source entity.</param>
		public static void InheritOwnersFrom<U>(this IUserGroupTrackingEntity<U> targetEntity, IUserGroupTrackingEntity<U> sourceEntity)
			where U : User
		{
			if (targetEntity == null) throw new ArgumentNullException(nameof(targetEntity));
			if (sourceEntity == null) throw new ArgumentNullException(nameof(sourceEntity));

			foreach (var user in sourceEntity.OwningUsers)
			{
				targetEntity.OwningUsers.Add(user);
			}
		}

		/// <summary>
		/// Inherit the owner of an entity.
		/// </summary>
		/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
		/// <param name="targetEntity">The receiving entity.</param>
		/// <param name="sourceEntity">The source entity.</param>
		public static void InheritOwnerFrom<U>(this IUserGroupTrackingEntity<U> targetEntity, IUserTrackingEntity<U> sourceEntity)
			where U : User
		{
			if (targetEntity == null) throw new ArgumentNullException(nameof(targetEntity));
			if (sourceEntity == null) throw new ArgumentNullException(nameof(sourceEntity));

			if (sourceEntity.OwningUser == null)
				throw new ArgumentException("The source entity has no owner.", nameof(sourceEntity));

			targetEntity.OwningUsers.Add(sourceEntity.OwningUser);
		}
	}
}

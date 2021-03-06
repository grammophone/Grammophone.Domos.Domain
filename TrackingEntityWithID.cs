﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Base class for entities having primary key and supporting change tracking.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="K">The type of primary key.</typeparam>
	[Serializable]
	public abstract class TrackingEntityWithID<U, K> : TrackingEntity<U>, IEntityWithID<K>
		where U : User
	{
		/// <summary>
		/// The primary key.
		/// </summary>
		[Required]
		[Key]
		public virtual K ID { get; set; }
	}
}

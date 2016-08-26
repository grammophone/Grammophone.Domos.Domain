﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Abstract base for segregated areas of the system, such as companies,
	/// to support software-as-a-service scenarios.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class Segregation<U> : UserTrackingEntityWithID<U, long>, ISegregationTrackingEntity
		where U : User
	{
		#region Primitive properties

		/// <summary>
		/// This property is bound to <see cref="UserTrackingEntityWithID{U, K}.ID"/>.
		/// </summary>
		long ISegregationTrackingEntity.SegregationID
		{
			get
			{
				return this.ID;
			}
			set
			{
				this.ID = value;
			}
		}

		#endregion
	}
}

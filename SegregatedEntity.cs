﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Base for entities belonging to a segregation.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/></typeparam>
	[Serializable]
	public abstract class SegregatedEntity<U, S> : ISegregatedEntity<U, S>
		where U : User
		where S : Segregation<U>
	{
		#region Private fields

		private SegregatedTrait<U, S> segregatedTrait;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The ID of the segregation where this entity belongs.
		/// Once set, cannot be changed.
		/// </summary>
		public virtual long SegregationID
		{
			get
			{
				return segregatedTrait.SegregationID;
			}
			set
			{
				segregatedTrait.SegregationID = value;
			}
		}

		/// <summary>
		/// The segregation where this entity belongs.
		/// Once set, cannot be changed.
		/// </summary>
		public virtual S Segregation
		{
			get
			{
				return segregatedTrait.Segregation;
			}
			set
			{
				segregatedTrait.Segregation = value;
			}
		}

		#endregion
	}
}

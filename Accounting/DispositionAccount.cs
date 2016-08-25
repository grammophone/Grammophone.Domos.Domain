﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// An account owned by a <see cref="Disposition"/>
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	/// <typeparam name="D">The type of the disposition, derived from <see cref="Disposition{U}"/>.</typeparam>
	[Serializable]
	public class DispositionAccount<U, S, D> : UserAccount<U>, IDispositionTrackingEntity<U, S, D>
		where U : User
		where S : Segregation<U>
		where D : Disposition<U>
	{
		#region Private fields

		private SegregationTrackingTrait<U, S> segregationTrackingTrait;

		private DispositionTrackingTrait<U, D> dispositionTrackingTrait;

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual long OwnerDispositionID
		{
			get
			{
				return dispositionTrackingTrait.OwnerDispositionID;
			}

			set
			{
				dispositionTrackingTrait.OwnerDispositionID = value;
			}
		}

		/// <summary>
		/// The disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual D OwnerDisposition
		{
			get
			{
				return dispositionTrackingTrait.OwnerDisposition;
			}
			set
			{
				dispositionTrackingTrait.OwnerDisposition = value;
			}
		}

		/// <summary>
		/// The ID of the segregation where this entity belongs.
		/// Once set, cannot be changed.
		/// </summary>
		public virtual long SegregationID
		{
			get
			{
				return segregationTrackingTrait.SegregationID;
			}

			set
			{
				segregationTrackingTrait.SegregationID = value;
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
				return segregationTrackingTrait.Segregation;
			}
			set
			{
				segregationTrackingTrait.Segregation = value;
			}
		}

		#endregion
	}
}
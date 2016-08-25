using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base class for entities supporting user ownership and change tracking
	/// as well as belonging to a segregation.
	/// </summary>
	/// <typeparam name="U">The type of user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	[Serializable]
	public abstract class UserSegregationTrackingEntity<U, S> : 
		UserTrackingEntity<U>, ISegregationTrackingEntity<U, S>
		where U : User
		where S : Segregation<U>
	{
		#region Private fields

		private SegregationTrackingTrait<U, S> segregationTrackingTrait;

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

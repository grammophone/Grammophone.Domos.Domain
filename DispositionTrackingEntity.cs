using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base class for entities belonging to a segregation 
	/// and supporting user disposition ownership and change tracking against that segregation.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/>.</typeparam>
	/// <typeparam name="D">The type of the disposition, derived from <see cref="Disposition{U}"/>.</typeparam>
	[Serializable]
	public abstract class DispositionTrackingEntity<U, S, D> : 
		UserSegregationTrackingEntity<U, S>, IDispositionTrackingEntity<U, S, D>
		where U : User
		where S : Segregation<U>
		where D : Disposition<U>
	{
		#region Private fields

		private DispositionTrackingTrait<U, D> dispositionTrackingTrait;

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual long OwningDispositionID
		{
			get
			{
				return dispositionTrackingTrait.OwningDispositionID;
			}
			set
			{
				dispositionTrackingTrait.OwningDispositionID = value;
			}
		}

		/// <summary>
		/// The disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		[IgnoreDataMember]
		public virtual D OwningDisposition
		{
			get
			{
				return dispositionTrackingTrait.OwningDisposition;
			}
			set
			{
				dispositionTrackingTrait.OwningDisposition = value;
			}
		}

		#endregion
	}
}

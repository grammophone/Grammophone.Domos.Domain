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
	[Serializable]
	public abstract class DispositionTrackingEntity<U> : UserSegregationTrackingEntity<U>, IDispositionTrackingEntity<U>
		where U : User
	{
		#region Private fields

		private long ownerDispositionID;

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
				return ownerDispositionID;
			}
			set
			{
				if (ownerDispositionID != value)
				{
					if (ownerDispositionID != 0L)
						throw new DomainAccessDeniedException("The owner disposition ID cannot be changed.", this);

					ownerDispositionID = value;
				}
			}
		}

		#endregion
	}
}

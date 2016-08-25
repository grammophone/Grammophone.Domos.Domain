using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// A trait to aid implementation of <see cref="IDispositionTrackingEntity{U}"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="D">The type of the disposition, derived from <see cref="Disposition{U}"/>.</typeparam>
	[Serializable]
	public struct DispositionTrackingTrait<U, D>
		where U : User
		where D : Disposition<U>
	{
		#region Private fields

		private long owningDispositionID;

		private D owningDisposition;

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		public long OwningDispositionID
		{
			get
			{
				return owningDispositionID;
			}
			set
			{
				if (owningDispositionID != value)
				{
					if (owningDispositionID != 0L)
						throw new DomainAccessDeniedException("The owning disposition ID cannot be changed.", this);

					owningDispositionID = value;
				}
			}
		}

		/// <summary>
		/// The disposition which owns this entity.
		/// Once set, cannot be changed.
		/// </summary>
		public D OwningDisposition
		{
			get
			{
				return owningDisposition;
			}
			set
			{
				if (owningDisposition != value)
				{
					if (owningDisposition != null)
						throw new DomainAccessDeniedException("The owning disposition ID cannot be changed.", this);

					owningDisposition = value;
				}
			}
		}

		#endregion
	}
}

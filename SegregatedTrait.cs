using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A trait to aid implementation of <see cref="ISegregatedEntity"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="S">The type of the segregation, derived from <see cref="Segregation{U}"/></typeparam>
	[Serializable]
	public struct SegregatedTrait<U, S>
		where U : User
		where S : Segregation<U>
	{
		#region Private fields

		private long segregationID;

		private S segregation;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The ID of the segregation where this entity belongs.
		/// Once set, cannot be changed.
		/// </summary>
		public long SegregationID
		{
			get
			{
				return segregationID;
			}
			set
			{
				if (segregationID != value)
				{
					if (segregationID != 0L) throw new DomainAccessDeniedException("The segregation cannot be changed.", this);

					segregationID = value;
				}
			}
		}

		/// <summary>
		/// The segregation where this entity belongs.
		/// Once set, cannot be changed.
		/// </summary>
		public S Segregation
		{
			get
			{
				return segregation;
			}
			set
			{
				if (segregation != value)
				{
					if (segregation != null) throw new DomainAccessDeniedException("The segregation cannot be changed.", this);

					segregation = value;
				}
			}
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// Base for entities belonging to a segregation.
	/// </summary>
	[Serializable]
	public abstract class SegregationTrackingEntity : ISegregationTrackingEntity
	{
		#region Private fields

		private long segregationID;

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

		#endregion
	}
}

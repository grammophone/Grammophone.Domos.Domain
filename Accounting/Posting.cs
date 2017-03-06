using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// A double-entry accounting record to represent internal credit flow. 
	/// It is always balanced with other postings in <see cref="Journal{U, ST, P, R}.Postings"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	[Serializable]
	public abstract class Posting<U> : JournalLine<U>
		where U : User
	{
	}
}

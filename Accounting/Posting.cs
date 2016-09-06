using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain.Accounting
{
	/// <summary>
	/// A double-entry accounting record to represent internal credit flow. 
	/// It is always balanced with other postings in <see cref="Journal{U, ST, A, P, R}.Postings"/>.
	/// </summary>
	/// <typeparam name="U">The type of the user, derived from <see cref="User"/>.</typeparam>
	/// <typeparam name="A">The type of account, derived from <see cref="Account{U}"/>.</typeparam>
	[Serializable]
	public abstract class Posting<U, A> : JournalLine<U, A>
		where U : User
		where A : Account<U>
	{
	}
}

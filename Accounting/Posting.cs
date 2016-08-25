using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain.Accounting
{
	/// <summary>
	/// A double-entry accounting record to represent internal credit flow. 
	/// It is always balanced with other postings in <see cref="Journal{U}.Lines"/>.
	/// </summary>
	[Serializable]
	public class Posting<U> : JournalLine<U>
		where U : User
	{
	}
}

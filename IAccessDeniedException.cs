using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Interface to mark an exception as an access denial.
	/// </summary>
	public interface IAccessDeniedException
	{
		/// <summary>
		/// The exception message.
		/// </summary>
		string Message { get; }
	}
}

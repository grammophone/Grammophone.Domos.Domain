using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Users.Domain
{
	/// <summary>
	/// The provider by which the user is registered to the system.
	/// </summary>
	public enum RegistrationProvider
	{
		Native,
		Facebook,
		LinkedIn,
		Twitter,
		Google,
		Microsoft
	}
}

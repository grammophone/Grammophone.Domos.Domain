using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// The provider by which the user is registered to the system.
	/// </summary>
	public enum RegistrationProvider
	{
		/// <summary>
		/// Registrationn using password.
		/// </summary>
		Native,

		/// <summary>
		/// Registration using Facebook.
		/// </summary>
		Facebook,

		/// <summary>
		/// Registgration using LinkedIn.
		/// </summary>
		LinkedIn,

		/// <summary>
		/// Registration using Twitter.
		/// </summary>
		Twitter,

		/// <summary>
		/// Registration using Google.
		/// </summary>
		Google,

		/// <summary>
		/// Registration using Mocrosoft's Live.
		/// </summary>
		Microsoft
	}
}

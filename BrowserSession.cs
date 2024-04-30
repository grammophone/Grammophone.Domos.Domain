using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// The browser sessions the user has established with the system.
	/// </summary>
	public class BrowserSession : EntityWithID<long>, IOwnedEntity<User>
	{
		#region Constants

		/// <summary>
		/// The length of the <see cref="FingerPrint"/> property.
		/// </summary>
		public const int FingerPrintLength = 128;

		/// <summary>
		/// The length of the <see cref="OperatingSystem"/> property.
		/// </summary>
		public const int OperatingSystemLength = 128;

		/// <summary>
		/// The length of the <see cref="Browser"/> property.
		/// </summary>
		public const int BrowserLength = 128;

		/// <summary>
		/// The length of the <see cref="SecurityStamp"/> property.
		/// </summary>
		public const int SecurityStampLength = 68;

		#endregion

		#region Private Fields

		private ICollection<ClientIpAddress> ipAddresses;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The computed fingerprint of the browser.
		/// </summary>
		[Required]
		[MaxLength(FingerPrintLength)]
		public virtual string FingerPrint { get; set; }

		/// <summary>
		/// The operating system of the client.
		/// </summary>
		[Display(
			ResourceType = typeof(BrowserSessionResources),
			Name = nameof(BrowserSessionResources.OperatingSystem_Name))]
		[MaxLength(OperatingSystemLength)]
		public virtual string OperatingSystem { get; set; }

		/// <summary>
		/// The date where the browser first signed in.
		/// </summary>
		[Display(
		 ResourceType = typeof(BrowserSessionResources),
		 Name = nameof(BrowserSessionResources.FirstSignInOn_Name))]
		public virtual DateTime FirstSignInOn { get; set; }

		/// <summary>
		/// The date the browser last seen.
		/// </summary>
		[Display(
			ResourceType = typeof(BrowserSessionResources),
			Name = nameof(BrowserSessionResources.LastSeenOn_Name))]
		public virtual DateTime LastSeenOn { get; set; }

		/// <summary>
		/// The browser used.
		/// </summary>
		[Display(
		 ResourceType = typeof(BrowserSessionResources),
		 Name = nameof(BrowserSessionResources.Browser_Name))]
		[MaxLength(BrowserLength)]
		public virtual string Browser { get; set; } = string.Empty;

		/// <summary>
		/// The security stamp used of session cryptographic opearation such
		/// as creating the authentication cookie and validating it.
		/// </summary>
		[Required(AllowEmptyStrings = true)]
		[MaxLength(SecurityStampLength)]
		public virtual string SecurityStamp { get; set; }

		/// <summary>
		/// Whether this session is logged off.
		/// </summary>
		[Display(
		 ResourceType = typeof(BrowserSessionResources),
		 Name = nameof(BrowserSessionResources.IsLoggedOff_Name))]
		public virtual bool IsLoggedOff { get; set; } = false;

		#endregion

		#region Relations

		/// <summary>
		/// The Id of the Lifeaccount User associated with the session.
		/// </summary>
		public virtual long UserID { get; set; }

		/// <summary>
		/// The lifeaccount user associated with the browser session.
		/// </summary>
		public virtual User User { get; set; }

		/// <summary>
		/// The ip addresses related to the browser session.
		/// </summary>
		public virtual ICollection<ClientIpAddress> IPAddresses
		{
			get
			{
				return ipAddresses ?? (ipAddresses = new HashSet<ClientIpAddress>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				ipAddresses = value;
			}
		}

		#endregion

		#region IOwnedEntity implementation

		/// <inheritdoc/>
		public bool IsOwnedBy(User user) => this.UserID == user?.ID;

		#endregion
	}
}

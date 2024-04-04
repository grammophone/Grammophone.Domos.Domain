using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Ip address of a browser session
	/// </summary>
	[Serializable]
	public class ClientIpAddress : EntityWithID<long>, IOwnedEntity<User>
	{
		#region Primitive properties

		/// <summary>
		/// The ip address ip v4 or ip v6.
		/// </summary>
		[Required]
		[MaxLength(39)]
		[Display(
			ResourceType = typeof(ClientIpAddressResources),
			Name = nameof(ClientIpAddressResources.IpAddress_Name))]
		public virtual string IpAddress { get; set; }

		/// <summary>
		/// The date and time the user was last seen in the session.
		/// </summary>
		[Display(
			ResourceType = typeof(ClientIpAddressResources),
			Name = nameof(ClientIpAddressResources.LastSeen_Name))]
		public virtual DateTime LastSeen { get; set; }

		/// <summary>
		/// The country.
		/// </summary>
		[MaxLength(100)]
		[Display(
			ResourceType = typeof(ClientIpAddressResources),
			Name = nameof(ClientIpAddressResources.Country_Name))]
		public virtual string Country { get; set; }

		/// <summary>
		/// The region of the country, it should be a province for canada.
		/// </summary>
		[MaxLength(40)]
		[Display(
			ResourceType = typeof(ClientIpAddressResources),
			Name = nameof(ClientIpAddressResources.Region_Name))]
		public virtual string Region { get; set; }

		/// <summary>
		/// The city of the IP address.
		/// </summary>
		[MaxLength(100)]
		[Display(
			ResourceType = typeof(ClientIpAddressResources),
			Name = nameof(ClientIpAddressResources.City_Name))]
		public virtual string City { get; set; }

		/// <summary>
		/// The raw data.
		/// </summary>
		[DataType(DataType.MultilineText)]
		[Display(
			ResourceType = typeof(ClientIpAddressResources),
			Name = nameof(ClientIpAddressResources.RawIpServiceData_Name))]
		public virtual string RawIpServiceData { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the browser session in which this IP address was recorded.
		/// </summary>
		public virtual long? BrowserSessionID { get; set; }

		/// <summary>
		/// The browser session in which this IP address was recorded.
		/// </summary>
		public virtual BrowserSession BrowserSession { get; set; }

		#endregion

		#region IOwnedEntity implementation

		/// <inheritdoc/>
		public bool IsOwnedBy(User user) => user?.ID == this.BrowserSession?.UserID;

		#endregion
	}
}

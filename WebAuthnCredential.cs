using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// Describes the type of the credential.
	/// See more on https://passkeys.dev/device-support/
	/// </summary>
	internal enum AuthenticatorPlatformType
	{
		/// <summary>
		/// Unknown platform type.
		/// </summary>
		Unknown = 10,

		/// <summary>
		/// Windows Hello. Created on a PC running Windows 10 and greater.
		/// </summary>
		WindowsHello = 20,

		/// <summary>
		/// Created on a MAC, IPhone, Ipad and it is stored and synchronized on icloud.
		/// </summary>
		ICloudKeychain = 30,

		/// <summary>
		/// Used the android device created and synced with a google account if google
		/// is used on the device.
		/// </summary>
		Android = 40,

		/// <summary>
		/// An external hardware authenticator such as Yubikeys etc.
		/// </summary>
		SecurityKey = 50
	}

	/// <summary>
	/// Represents a WebAuthn credential.
	/// </summary>
	[Serializable]
	internal class WebAuthnCredential<U> : TrackingEntityWithID<U, long>, IOwnedEntity<U>
		where U : User
	{
		#region Constants

		/// <summary>
		/// Maximum length of the <see cref="UserName"/> property.
		/// </summary>
		public const int UserNameLength = 256;

		/// <summary>
		/// Maximum length of the <see cref="UserHandle"/> property as defined by Webauthn is 64.
		/// </summary>
		public const int UserHandleLength = 64;

		/// <summary>
		/// Maximum length of the <see cref="CredentialFriendlyName"/> property.
		/// </summary>
		public const int CredentialFriendlyNameLength = 512;

		/// <summary>
		/// Maximum length of the <see cref="CredType"/> property.
		/// </summary>
		public const int CredTypeLength = 128;

		/// <summary>
		/// Maximun length for the <see cref="CredentialId"/> property.
		/// </summary>
		public const int CredentialIdLength = 256;

		#endregion

		#region Primitive properties

		/// <summary>
		/// The credentials friendly name in the system.
		/// </summary>
		[Required]
		[MaxLength(CredentialFriendlyNameLength)]
		[DataType(DataType.MultilineText)]
		[Display(ResourceType = typeof(WebAuthnCredentialResources),
			Name = nameof(WebAuthnCredentialResources.CredentialFriendlyName_Name),
			Description = nameof(WebAuthnCredentialResources.CredentialFriendlyName_Description))]
		public virtual string CredentialFriendlyName { get; set; }

		/// <summary>
		/// Gets or sets the user name for this user.
		/// </summary>
		[Required]
		[MaxLength(UserNameLength)]
		public virtual string UserName { get; set; }

		/// <summary>
		/// Gets or sets the public key for this user.
		/// </summary>
		[Required]
		public virtual byte[] PublicKey { get; set; }

		/// <summary>
		/// The user id cib as a byte array.
		/// </summary>
		[Required]
		[MaxLength(UserHandleLength)]
		public virtual byte[] UserId { get; set; }

		/// <summary>
		/// Gets or sets the user handle for this user. It is passed to the authenticator.
		/// It must not have 
		/// </summary>
		[Required]
		[MaxLength(UserHandleLength)]
		public virtual byte[] UserHandle { get; set; }

		/// <summary>
		/// The ID of the credential. It is created by the authenticator.
		/// </summary>
		[Required]
		[MaxLength(CredentialIdLength)]
		public virtual byte[] CredentialId { get; set; }

		/// <summary>
		/// The signature counter.
		/// </summary>
		public virtual uint SignatureCounter { get; set; }

		/// <summary>
		/// The type of the credential.
		/// </summary>
		[Required]
		[MaxLength(CredTypeLength)]
		public virtual string CredType { get; set; }

		/// <summary>
		/// Gets or sets the registration date for this user in UTC.
		/// </summary>
		public virtual DateTime RegDate { get; set; }

		/// <summary>
		/// Gets or sets the Authenticator Attestation GUID (AAGUID) for this user.
		/// </summary>
		/// <remarks>
		/// An AAGUID is a 128-bit identifier indicating the type of the authenticator.
		/// </remarks>
		public virtual Guid AaGuid { get; set; }

		/// <summary>
		/// The PublicKeyCredentialDescriptor stored as a string.
		/// </summary>
		public virtual string DescriptorJson { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the user owning the credential.
		/// </summary>
		public virtual long OwnerID { get; set; }

		/// <summary>
		/// The user owning the credential.
		/// </summary>
		public virtual U Owner { get; set; }

		#endregion

		#region IOWnedEntity implementaiton

		/// <inheritdoc/>
		public bool IsOwnedBy(U user) => user?.ID == this.OwnerID;

		/// <summary>
		/// The platform (OS) of the authenticator that the current webauthn credential resides.
		/// </summary>
		public virtual AuthenticatorPlatformType PlatformType { get; set; }

		#endregion
	}
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A registration via a <see cref="RegistrationProvider"/>
	/// </summary>
	[Serializable]
	public class Registration : EntityWithID<long>, IOwnedEntity<User>
	{
		#region Primitive properties

		/// <summary>
		/// Method for logging in.
		/// </summary>
		public virtual RegistrationProvider Provider { get; set; }

		/// <summary>
		/// The key assigned to the user by the registration provider.
		/// </summary>
		[MaxLength(128)]
		[IgnoreDataMember]
		public virtual string ProviderKey { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The ID of the user.
		/// </summary>
		public virtual long UserID { get; set; }

		/// <summary>
		/// The user.
		/// </summary>
		public virtual User User { get; set; }

		#endregion

		#region IOwnedEntity implementation

		/// <summary>
		/// Returns true when a <paramref name="user"/> has ID equal to <see cref="UserID"/>.
		/// </summary>
		public bool IsOwnedBy(User user) => user.ID == this.UserID;

		/// <summary>
		/// Returns true when a <paramref name="userID"/> is equal to <see cref="UserID"/>.
		/// </summary>
		public bool IsOwnedBy(long userID) => userID == this.UserID;

		#endregion
	}
}

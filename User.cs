using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grammophone.Domos.Domain
{
	/// <summary>
	/// A user in the system.
	/// </summary>
	[Serializable]
	public abstract class User : EntityWithID<long>, IOwnedEntity<User>
	{
		#region Private fields

		/// <summary>
		/// Empty collection of dispositions, used by
		/// method <see cref="GetDispositionsBySegregationID(long)"/> when needed.
		/// </summary>
		private static IReadOnlyCollection<Disposition> emptyDispositionsList = new Disposition[0];

		/// <summary>
		/// Backing field for <see cref="Roles"/>.
		/// </summary>
		private ICollection<Role> roles;

		/// <summary>
		/// Backing field for <see cref="Dispositions"/>.
		/// </summary>
		private ICollection<Disposition> dispositions;

		/// <summary>
		/// Backing field for <see cref="registrations"/>.
		/// </summary>
		private ICollection<Registration> registrations;

		/// <summary>
		/// Grouping of dispositions by <see cref="Disposition.SegregationID"/>.
		/// Created on-demand by <see cref="GetDispositionsBySegregationID(long)"/>.
		/// </summary>
		private Dictionary<long, List<Disposition>> dispositionsBySegregationID;

		#endregion

		#region Construction

		/// <summary>
		/// Create.
		/// </summary>
		public User()
		{
			this.SecurityStamp = String.Empty;
		}

		#endregion

		#region Primitive properties

		/// <summary>
		/// The user's code name.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[IgnoreDataMember]
		[Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.UserName_Name))]
		public virtual string UserName { get; set; }

		/// <summary>
		/// The user's e-mail.
		/// </summary>
		[EmailAddress]
		[Required]
		[MaxLength(256)]
		[IgnoreDataMember]
		[Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.Email_Name))]
		public virtual string Email { get; set; }

		/// <summary>
		/// Optional password hash, used only when 
		/// using native registration.
		/// </summary>
		[MaxLength(1024)]
		[IgnoreDataMember]
		public virtual string PasswordHash { get; set; }

		/// <summary>
		/// First name.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.FirstName_Name))]
		public virtual string FirstName { get; set; }

		/// <summary>
		/// Last name.
		/// </summary>
		[Required]
		[MaxLength(256)]
		[Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.LastName_Name))]
		public virtual string LastName { get; set; }

		/// <summary>
		/// True if this is a system account.
		/// </summary>
		[IgnoreDataMember]
		[Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.IsSystem_Name))]
		public virtual bool IsSystem { get; set; }

		/// <summary>
		/// True if the user is the special "Anonymous" one.
		/// </summary>
		[IgnoreDataMember]
		[Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.IsAnonymous_Name))]
		public virtual bool IsAnonymous { get; set; }

		/// <summary>
		/// The registration status of the user.
		/// </summary>
		[Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.RegistrationStatus_Name))]
		public virtual RegistrationStatus RegistrationStatus { get; set; }

		/// <summary>
		/// A security stamp that is updated whenever there is a change in the user's credentials.
		/// </summary>
		[IgnoreDataMember]
		[MaxLength(512)]
		[Required(AllowEmptyStrings = true)]
		public virtual string SecurityStamp { get; set; }

		/// <summary>
		/// Date when the user was created.
		/// </summary>
		[Display(ResourceType = typeof(UserResources), Name = nameof(UserResources.CreationDate_Name))]
		public virtual DateTime CreationDate { get; set; }

		/// <summary>
		/// An optional unique identifier for the user.
		/// </summary>
		/// <remarks>
		/// This is not elected as the primary key for two reasons:
		/// <list type="bullet">
		/// <item>It is intended to be unpredictable.</item>
		/// <item>The <see cref="EntityWithID{K}.ID"/> is more lightweight as a primary and foreign key.</item>
		/// </list>
		/// </remarks>
		public virtual Guid Guid { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// The system-wide roles of the user.
		/// </summary>
		public virtual ICollection<Role> Roles
		{
			get
			{
				return roles ?? (roles = new HashSet<Role>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				roles = value;
			}
		}

		/// <summary>
		/// The segregation-wide roles of the user.
		/// </summary>
		public virtual ICollection<Disposition> Dispositions
		{
			get
			{
				return dispositions ?? (dispositions = new System.Collections.ObjectModel.ObservableCollection<Disposition>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				dispositions = value;

				FlushDispositionsBySegregationIdCache();
			}
		}

		/// <summary>
		/// The external login registrations of the user.
		/// </summary>
		public virtual ICollection<Registration> Registrations
		{
			get
			{
				return registrations ?? (registrations = new HashSet<Registration>());
			}
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(value));

				registrations = value;
			}
		}

		/// <summary>
		/// Returns true when the given user is the same.
		/// </summary>
		bool IOwnedEntity<User>.IsOwnedBy(User user) => this == user;

		#endregion

		#region Public methods

		/// <summary>
		/// Get the dispositions of the user against a segregation.
		/// </summary>
		/// <param name="segregationID">The ID of the segregation.</param>
		/// <returns>Returns the dispositions found or an empty collection.</returns>
		public IReadOnlyCollection<Disposition> GetDispositionsBySegregationID(long segregationID)
		{
			EnsureDispositionsBySegregationID();

			if (dispositionsBySegregationID.TryGetValue(segregationID, out List<Disposition> dispositionsOfSegregation))
			{
				return dispositionsOfSegregation;
			}
			else
			{
				return emptyDispositionsList;
			}
		}

		/// <summary>
		/// Flush the cached grouping of dispositions by segregation ID
		/// used in method <see cref="GetDispositionsBySegregationID(long)"/>.
		/// </summary>
		/// <remarks>
		/// If the default <see cref="Dispositions"/> collection is used or
		/// if a collection implementing <see cref="INotifyCollectionChanged"/> is set to
		/// the <see cref="Dispositions"/> proeprty or
		/// if proxy creation is enabled by the data access framework and
		/// the proxy implements <see cref="INotifyCollectionChanged"/> for the proxied colections,
		/// as is the case with Entity Framework with change tracking,
		/// this call is not needed; the <see cref="GetDispositionsBySegregationID(long)"/> will always
		/// fetch current data.
		/// Otherwiase, after a call to <see cref="GetDispositionsBySegregationID(long)"/> has been done
		/// and then the <see cref="Dispositions"/> collection has been altered,
		/// call this method before calling <see cref="GetDispositionsBySegregationID(long)"/> again.
		/// </remarks>
		public void FlushDispositionsBySegregationIdCache()
		{
			if (dispositionsBySegregationID != null)
			{
				// Does the Dispositions collection support item notifications?
				if (this.Dispositions is INotifyCollectionChanged changeNotifier)
				{
					changeNotifier.CollectionChanged -= OnDispositionsChanged;
				}
			}

			dispositionsBySegregationID = null;
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Build the grouping of dispositions by segregation ID,
		/// discarding any previous existing.
		/// </summary>
		private void BuildDispositionsBySegregationID()
		{
			FlushDispositionsBySegregationIdCache();

			dispositionsBySegregationID = new Dictionary<long, List<Disposition>>();

			foreach (var disposition in this.Dispositions)
			{
				AddDispositionToCache(disposition);
			}

			// Does the Dispositions collection support item notifications?
			if (this.Dispositions is INotifyCollectionChanged changeNotifier)
			{
				changeNotifier.CollectionChanged += OnDispositionsChanged;
			}
		}

		/// <summary>
		/// If there is no grouping of dispositions by segratation ID yet,
		/// build it.
		/// </summary>
		private void EnsureDispositionsBySegregationID()
		{
			if (dispositionsBySegregationID == null)
			{
				BuildDispositionsBySegregationID();
			}
		}

		/// <summary>
		/// If there exists a grouping of dispositions by segragation ID, add a disposition to it.
		/// </summary>
		/// <param name="disposition">The disposition to add to the grouping.</param>
		private void AddDispositionToCache(Disposition disposition)
		{
			if (disposition == null) throw new ArgumentNullException(nameof(disposition));

			if (dispositionsBySegregationID == null) return;

			if (!dispositionsBySegregationID.TryGetValue(disposition.SegregationID, out List<Disposition> dispositionsOfSegregation))
			{
				dispositionsOfSegregation = new List<Disposition>();
				dispositionsBySegregationID[disposition.SegregationID] = dispositionsOfSegregation;
			}

			dispositionsOfSegregation.Add(disposition);
		}

		/// <summary>
		/// If there exists a grouping of dispositions by segragation ID, remove a disposition from it.
		/// </summary>
		/// <param name="disposition">The disposition to remove from the grouping.</param>
		private void RemoveDispositionFromCache(Disposition disposition)
		{
			if (disposition == null) throw new ArgumentNullException(nameof(disposition));

			if (dispositionsBySegregationID == null) return;

			if (dispositionsBySegregationID.TryGetValue(disposition.SegregationID, out List<Disposition> dispositionsOfSegregation))
			{
				dispositionsOfSegregation.Remove(disposition);
			}
		}

		/// <summary>
		/// Called when the collection supporting the <see cref="Dispositions"/> property
		/// supports <see cref="INotifyCollectionChanged"/> and there
		/// exists a grouping of dispositions by segregation ID.
		/// </summary>
		private void OnDispositionsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (dispositionsBySegregationID == null) return;

			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					foreach (Disposition disposition in e.NewItems)
					{
						AddDispositionToCache(disposition);
					}
					break;

				case NotifyCollectionChangedAction.Remove:
					foreach (Disposition disposition in e.OldItems)
					{
						RemoveDispositionFromCache(disposition);
					}
					break;

				case NotifyCollectionChangedAction.Replace:
					foreach (Disposition disposition in e.OldItems)
					{
						RemoveDispositionFromCache(disposition);
					}
					foreach (Disposition disposition in e.NewItems)
					{
						AddDispositionToCache(disposition);
					}
					break;

				case NotifyCollectionChangedAction.Move:
					break;

				default:
					FlushDispositionsBySegregationIdCache();
					break;
			}
		}

		#endregion
	}
}

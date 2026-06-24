# Security Ontology

Domos authorization is built around a small ontology that can be reused by concrete applications without making the framework depend on their business entities.

Domos distinguishes three authorization scopes:

- Entity access decides whether the active user can create, read, write or delete domain entities.
- Logic-manager access decides whether a user may obtain a manager object from a logic session and therefore use the operations exposed by that manager.
- Workflow access decides whether a user may execute a `StatePath` over an `IStateful` entity.

## Roles

`Role` is the system-wide assignment mechanism. Roles are connected to users through `User.Roles`. A role applies without reference to any tenant, record label, company, department or other segregation.

In a music-domain application, a role named `CatalogOperator` could grant read access to all `Artist` and `Album` entities and access to a global `CatalogManager`. A role named `SystemAdministrator` could grant broad administrative access.

Roles are suitable for system-wide responsibilities. They are not suitable for granting rights only inside one compartment of data.

## Segregations And Dispositions

`Segregation<U>` represents a compartment of data. A SaaS tenant is a typical segregation. In the music-domain examples, `RecordLabel : Segregation<MusicUser>` is the compartment.

`DispositionType` is role-like, but scoped to a segregation. `Disposition` is the explicit assignment joining a user, a disposition type and a segregation identifier. Concrete applications normally derive concrete disposition classes from `Disposition` when the assignment itself has business meaning.

For example:

```csharp
public class RecordLabel : Segregation<MusicUser>
{
}

public abstract class RecordLabelDisposition : Disposition,
	IDisposition<MusicUser, RecordLabel>
{
	public virtual MusicUser User { get; set; }

	public virtual RecordLabel RecordLabel { get; set; }

	RecordLabel IDisposition<MusicUser, RecordLabel>.Segregation => RecordLabel;
}

public class RecordLabelAdministrator : RecordLabelDisposition
{
}
```

Entities that belong to a segregation implement `ISegregatedEntity`. This allows access checking to locate the relevant segregation and combine rights granted by the user's dispositions for that segregation.

```csharp
public class Album : EntityWithID<long>,
	ISegregatedEntity<RecordLabel>,
	IOwnedEntity<MusicUser>
{
	public virtual long RecordLabelID { get; set; }

	public virtual RecordLabel RecordLabel { get; set; }

	long ISegregatedEntity.SegregationID => RecordLabelID;

	RecordLabel ISegregatedEntity<RecordLabel>.Segregation => RecordLabel;

	public virtual long OwnerID { get; set; }

	public virtual MusicUser Owner { get; set; }

	public bool IsOwnedBy(MusicUser user) => user != null && user.ID == OwnerID;
}
```

If `RecordLabelAdministrator` is assigned a permission that grants write rights over `Album`, the user can write albums only for the `RecordLabel` against which that disposition is assigned.

## Ownership

Ownership is represented by interfaces such as `IOwnedEntity<TUser>` and `IUpdatableOwnerEntity<TUser>`. Owned entities enable fine-grained access rules such as read-own, write-own, create-own or delete-own.

In the music domain, `Album` and `Track` can be segregated by `RecordLabel` and also owned by a `MusicUser`. A permission can therefore say that a contributor may edit their own tracks, while a `RecordLabelAdministrator` may edit every track within the label.

## Access Rights Are Aggregated

At runtime, the access resolver combines rights from:

- The user's roles.
- The user's dispositions for the relevant segregation.
- Default anonymous or authenticated roles declared in permissions setup.

The resolver first checks system-wide role rights. For segregated entities, it additionally checks disposition rights for the entity's segregation. For owned entities, it can also apply own-rights.

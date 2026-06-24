# Music Domain Example

This documentation uses a fictional music catalog to explain Domos concepts without relying on any private application model.

The example is intentionally small. It is not a complete domain design; it exists only to demonstrate users, segregations, dispositions, ownership and workflow.

## Users

Application users derive from `User`:

```csharp
public class MusicUser : User
{
}
```

`MusicUser` is the type used by the domain container, logic session, identity store and access resolver.

## Segregation

A record label is the data compartment:

```csharp
public class RecordLabel : Segregation<MusicUser>
{
	public virtual string Name { get; set; }
}
```

Albums, artists and tracks can belong to a record label. A user's rights over one record label do not imply rights over another.

## Dispositions

Disposition entities represent role-like assignments scoped to a record label:

```csharp
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

If `RecordLabelAdministrator` is assigned the permission `ManageRecordLabelCatalog`, that permission applies only to entities whose `RecordLabelID` matches the disposition's segregation ID.

## Segregated And Owned Entities

Albums and tracks can be both segregated and owned:

```csharp
public class Album : EntityWithID<long>,
	ISegregatedEntity<RecordLabel>,
	IOwnedEntity<MusicUser>,
	IStateful<MusicUser, AlbumStateTransition>
{
	public virtual long RecordLabelID { get; set; }

	public virtual RecordLabel RecordLabel { get; set; }

	public virtual long OwnerID { get; set; }

	public virtual MusicUser Owner { get; set; }

	public virtual State State { get; set; }

	public virtual ICollection<AlbumStateTransition> StateTransitions { get; }

	long ISegregatedEntity.SegregationID => RecordLabelID;

	RecordLabel ISegregatedEntity<RecordLabel>.Segregation => RecordLabel;

	public bool IsOwnedBy(MusicUser user) => user != null && user.ID == OwnerID;
}
```

`Track` can follow the same pattern. It can store its own `RecordLabelID`, or the application can derive the segregation from the owning album if that is made consistent in the model and access policy.

## Workflow

The album publishing workflow uses `AlbumStateTransition`:

```csharp
public class AlbumStateTransition : StateTransition<MusicUser>
{
	public virtual long AlbumID { get; set; }

	public virtual Album Album { get; set; }
}
```

The workflow graph can define paths such as `SubmitForReview`, `ApproveForRelease`, `RejectRelease` and `ArchiveAlbum`. The logic layer checks whether the current user may execute the selected path before recording the transition.

## Permissions

An application can grant `RecordLabelAdministrator` disposition types write rights over `Album`, `Artist` and `Track`, access to a `RecordLabelCatalogManager`, and access to publishing paths such as `ApproveForRelease`.

The same application can grant a system-wide role such as `CatalogOperator` broader read-only access across all record labels.

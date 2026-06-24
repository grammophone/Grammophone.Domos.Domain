# Workflow Entities

Workflow support is modeled through graph and transition entities.

`WorkflowGraph` represents a workflow definition. It has code and display names and records the state transition type used by the graph. `StateGroup` groups states within a workflow graph. `State` represents a workflow state. `StatePath` represents an executable transition path between previous and next states. Logic-layer workflow managers use state paths as the security and configuration target for workflow execution.

`StateTransition<TUser>` records a transition produced by executing a path. Stateful domain objects use `IStateful<TUser, TStateTransition>` to participate in workflows.

## Stateful Entities

`IStateful<TUser, TStateTransition>` lets a domain object expose its current state and its transition history. The framework does not require all entities to be stateful. Only entities that participate in workflows implement this contract.

In a music domain, `Album` can participate in an album publishing workflow:

```csharp
public class Album : EntityWithID<long>,
	IStateful<MusicUser, AlbumStateTransition>,
	ISegregatedEntity<RecordLabel>,
	IOwnedEntity<MusicUser>
{
	public virtual long StateID { get; set; }

	public virtual State State { get; set; }

	public virtual ICollection<AlbumStateTransition> StateTransitions { get; }

	public virtual long RecordLabelID { get; set; }

	public virtual long OwnerID { get; set; }
}

public class AlbumStateTransition : StateTransition<MusicUser>
{
	public virtual long AlbumID { get; set; }

	public virtual Album Album { get; set; }
}
```

The workflow graph might contain groups such as `Drafting`, `Reviewing`, `Published` and `Archived`, with paths such as `SubmitForReview`, `ApproveForRelease` and `ArchiveAlbum`.

## Workflow Security

Executing a `StatePath` is independently secured. A user may be able to read or write an album, but not necessarily approve it for publication. `StatePathAccess` entries in permissions setup grant the right to execute named paths.

In the music example, a `RecordLabelAdministrator` disposition can be granted access to `ApproveForRelease` for albums in that record label. A system-wide role can grant access to cross-label paths if the application needs that behavior.

## Workflow Actions

State paths can have configured actions before and after the state change. Actions are logic objects, not domain entities. They can validate dynamic arguments, create related records, send notifications or invoke accounting/funds-transfer logic in richer applications.

The workflow entity model records graph, state, path and transition history. The logic layer performs execution, access checking and action invocation.

# Workflow Entities

Workflow support is modeled through graph and transition entities.

`WorkflowGraph` represents a workflow definition. It has code and display names and records the state transition type used by the graph.

`StateGroup` groups states within a workflow graph.

`State` represents a workflow state.

`StatePath` represents an executable transition path between previous and next states. Logic-layer workflow managers use state paths as the security and configuration target for workflow execution.

`StateTransition<TUser>` records a transition produced by executing a path. Stateful domain objects use `IStateful<TUser, TStateTransition>` to participate in workflows.

The logic layer builds on these entities to cache workflow metadata, check access and invoke configured workflow actions.

# Security Ontology

Domos distinguishes several authorization scopes.

Entity access decides whether the active user can create, read, update or delete domain entities. Logic access decides whether managers or operations can be obtained and used. Workflow access decides whether a user can execute a `StatePath` over a stateful object.

`Role` is the system-wide RBAC-like assignment. Roles are connected to users through `User.Roles`.

`DispositionType` is role-like but scoped to a segregation. A `Disposition` is the explicit assignment between a user, a disposition type and a segregation identifier. In a SaaS application, a company or tenant is a typical segregation.

Ownership is represented by interfaces such as `IOwnedEntity<TUser>` and `IUpdatableOwnerEntity<TUser>`. Owned entities enable fine-grained access rules such as read-own or write-own.

Segregated entities are expected to expose a segregation identifier so access checking can apply disposition-scoped permissions.

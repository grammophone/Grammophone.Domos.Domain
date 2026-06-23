# Overview

`Grammophone.Domos.Domain` contains the core entity model for Domos applications.

The domain model is intentionally modular. A consumer can use only users and access control, add workflow, or add accounting and funds transfer support. The entities are designed to be mapped by multiple data-access providers through `Grammophone.Domos.DataAccess` contracts.

Main entity areas:

- Users, roles, registrations, dispositions and credentials.
- Workflow graphs, states, state paths and state transitions.
- Accounting accounts, credit systems, journals, postings and remittances.
- Funds transfer requests, events, batches, messages and banking-detail groups.
- Optional invoice, invoice line, tax component and invoice event abstractions.
- File metadata entities for storage-backed files.
- Tracking, ownership and segregation contracts.

Collection navigation defaults use `ObservableHashSet<T>` when they previously used `HashSet<T>`, preserving set semantics while supporting notification-aware change tracking. Existing observable collections, such as `User.Dispositions`, remain unchanged.

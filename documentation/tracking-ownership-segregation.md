# Tracking, Ownership And Segregation

Several base classes add cross-cutting domain traits.

`EntityWithID<K>` and `TrackingEntityWithID<TUser, K>` provide primary keys. `TrackingEntity<TUser>` adds creator, creation date, last modifier and last modification date through tracking traits.

`UserTrackingEntity<TUser>` and `UserTrackingEntityWithID<TUser, K>` add ownership semantics on top of tracking. Ownership is used by access checking and logic sessions.

Segregation contracts allow a domain to model tenant-like or partition-like boundaries. Dispositions are scoped to segregations, which lets the same user have different rights in different business partitions.

Consumers should derive concrete entities from the most specific base class that matches their required tracking and ownership semantics.

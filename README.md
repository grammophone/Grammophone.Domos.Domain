# Grammophone.Domos.Domain
This project contains the basic entity definitions 
of the Domos integrated session system.

It is part of the 3rd generation of the Domos integrated session system which will support SaaS, 
workflow and accounting scenarios.

## Overview
This library defines the core entities library required for a Domos system. It includes entities required to define users, internal credentials, external trusted authentication data by Identity Providers such as OAuth implementations and the base security, workflow and accounting mechanism.

Domos is a modular system which can use as much functionality as needed. Three main levels of functionality are offered out of the box:
* Access Control
* Access Control + Workflow
* Access Control + Workflow + Accounting

All levels have in common many optional features, such as virtual file system and others. For more information, see the [Domos Logic Layer](https://github.com/grammophone/Grammophone.Domos.Logic).

This library contains the base classes for domain entities required for these levels of functionality.

## Security Ontology
Domos has three layers of access control, which are used by the [Logic Layer library](https://github.com/grammophone/Grammophone.Domos.Logic)
built on top of this library and the [Access Checking library](https://github.com/grammophone/Grammophone.Domos.AccessChecking). These layers are:
1. Access control over domain entities, i.e. whether the current user can create, read, write, delete entities. 
2. Access Control whether "manager" objects can be obtained from a logic session, i.e. for obtaining access to related logic actions.
3. Access control over `StatePath` execution in workflows, i.e. the right to execute a transition from a previous state to a next state over some stateful entity.

These are organized in Permissions which are granted to the logic layer session user in one of two ways described below.

## Access Rights Assignment
The user of a logic session can gain access to any artifact of the aforementioned layers by any of the following ways:
1. Via `Role`s: Roles are system-wide enablers for users possessing them to access entities, managers and `StatePath` executions.
2. Via `Disposition`s: These are role-like assignments but specific only to entities belonging to a `Segregation`. Typical example of segregation can be a Company entity in a Software-As-A-Service scenario. Entities belonging to a segregation implement the `ISegregatedEntity` interface.

If entities implement the `IOwnedEntity` interface, there's also fine-grain access control like 'read own', 'write own' etc.

## Roles and Disposition Types
`Role` entities are the typical enablers found in standard RBAC systems for enabling `User`-derived entities to access artifacts, and are connected to `User`-derived entities via a many-to-many relationship.

`DispositionType` entities are much like roles, but they have two differences:
* They are assigned to a `User`-derived entity only with respect to a `Segregation`.
* The intermediate entity for implementing the many-to-many relationship is not implied but rather explicit and
derives from `Disposition`. For example when Bob is an employee of ACME Inc, he owns an 'Employee' disposition in his `User.Dispositions` property which has `Disposition.Type` set to 'Employment' and `Disposition.SegregationID` pointing to ACME Inc. His `Employee` disposition stores all properties and relationships required for his employment in the company.

Example of a role assignment is "Alice can manage all companies in the system".

Example of a disposition assignment is 'Bob is an Employee of ACME Inc" or "Susan is Company Administrator of ACME Inc".

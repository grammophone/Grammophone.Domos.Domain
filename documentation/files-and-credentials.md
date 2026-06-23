# Files And Credentials

Domos includes domain entities for authentication metadata and file metadata.

`Registration` records external identity-provider registrations for users. `WebAuthnCredential<TUser>` records passkey/WebAuthn credential metadata. `BrowserSession` and `ClientIpAddress` record session and IP-address information.

The `Files` namespace defines file metadata, content types and storage-related fields. Actual file contents are handled by the logic layer through `Grammophone.Storage`; domain file entities hold metadata and storage addressing information.

These entities are optional support components and can be included when a concrete application needs authentication, WebAuthn, session history or storage-backed file metadata.

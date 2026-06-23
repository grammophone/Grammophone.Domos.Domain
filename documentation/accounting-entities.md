# Accounting And Funds Transfer Entities

Domos accounting is centered on journals and funds transfer records.

`Account` represents an internal account. `CreditSystem` represents an external or internal system through which credit or funds move.

`Journal<TUser, TStateTransition, TPosting, TRemittance>` groups accounting lines. `Posting<TUser>` represents double-entry internal accounting lines. `Remittance<TUser>` represents external inflow or outflow where full double-entry recording is not available.

Funds transfer support uses `FundsTransferRequest`, `FundsTransferEvent`, `FundsTransferBatch`, `FundsTransferBatchMessage` and `FundsTransferRequestGroup`.

`FundsTransferRequestGroup` groups requests by encrypted banking detail. The embedded `EncryptedBankAccountInfo` stores encrypted account and transit information plus optional bank-format fields.

Invoice support is optional and generic. `Invoice`, `InvoiceLine`, `InvoiceLineTaxComponent` and `InvoiceEvent` are abstract bases intended to be specialized by applications.

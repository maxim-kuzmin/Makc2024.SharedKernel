﻿namespace Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.Create;

public record InvoiceCreateActionCommand(
  int Amount,
  Guid CustomerId,
  DateOnly Date,
  string Status) : ICommand<Result<Guid>>;

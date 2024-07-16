namespace Makc2024.Dummy.Gateway.Infrastructure.Invoice;

public class InvoiceRepository(AppDbContext dbContext) :
  AppRepositoryBase<InvoiceEntity>(dbContext),
  IInvoiceRepository
{
}
